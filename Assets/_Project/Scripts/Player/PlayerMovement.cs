using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMovement : MonoBehaviour
	{
		// Threshold value to consider the character as facing a direction
		private const float DirectionEpsilon = 0.001f;

		[SerializeField] private Camera cam;
		[Header("Parameters")]
		[SerializeField] private float speed = 5.0f;

		private Vector2 _input;
		private Vector2 _lookDir;
		private Rigidbody2D _rb;

		private float _speedModifier = 1f;

		private bool _isUsingMouse;
		private bool _isUsingRStick;
		private bool _isMoving;
		

		public MovementState MovementState { get; set; }
		public Direction Direction { get; private set; }

		private Vector2 Input
		{
			get => _input;
			set
			{
				_input = value;
				if (_input.magnitude >= 1)
				{
					_input.Normalize();
				}
			}
		}

		public Vector2 LookDir
		{
			get => _lookDir;
			set => _lookDir = value;
		}

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
			if (cam == null)
				cam = Camera.main;
		}

		[UsedImplicitly]
		private void OnMove(InputValue value)
		{
			var val = value.Get<Vector2>();
			Input = val;

			_isMoving = !Input.IsApproxZero();
		}

		[UsedImplicitly]
		private void OnLook(InputValue value)
		{
			var val = value.Get<Vector2>();
			if (val.IsApproxZero())
			{
				_isUsingRStick = false;
			}
			else
			{
				_lookDir = val.normalized;
				_isUsingRStick = true;
			}
		}

		[UsedImplicitly]
		private void OnControlsChanged(PlayerInput playerInput)
		{
			_isUsingMouse = (playerInput.currentControlScheme == "Keyboard&Mouse");
		}
		
		private void FixedUpdate()
		{
			ChangeLookDirection();
			ApplyMovement();
		}

		private void ChangeLookDirection()
		{
			if (_isUsingMouse)
			{
				Vector3 mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

				Vector2 playerMouse = mousePos - transform.position;
				_lookDir = playerMouse.normalized;
			}
			else if (!_isUsingRStick && _isMoving)
			{
				_lookDir = _rb.velocity.normalized;
			}

			if (_lookDir.IsApproxZero()) return;

			//transform.up = _lookDir;

			if (Mathf.Abs(_lookDir.x) > Mathf.Abs(_lookDir.y))
			{
				Direction = _lookDir.x switch
				{
					> DirectionEpsilon => Direction.Right,
					< -DirectionEpsilon => Direction.Left,
					_ => Direction,
				};
			}
			else
			{
				Direction = _lookDir.y switch
				{
					> DirectionEpsilon => Direction.Up,
					< -DirectionEpsilon => Direction.Down,
					_ => Direction,
				};
			}
		}

		private void ApplyMovement()
		{
			Vector2 input = Input;

		
			Vector2 vel = input * (speed * _speedModifier);

			switch (MovementState)
			{
				case MovementState.Idle:
				case MovementState.Walk:
					MovementState = vel.IsApproxZero() ? MovementState.Idle : MovementState.Walk;
					break;
				case MovementState.Attacking:
					break;
				default:
					break;
			}

			_rb.velocity = vel;
		}
	}
}