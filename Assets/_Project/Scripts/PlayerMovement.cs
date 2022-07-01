using JetBrains.Annotations;
using StowyTools.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EpicGameJam
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private Camera cam;
		[Header("Parameters")]
		[SerializeField] private float speed = 5.0f;

		private Vector2 _input;
		private Vector2 _lookDir;
		private Rigidbody2D _rb;
		private bool _hasMouse;

		private Vector2 Input
		{
			get => _input;
			set => _input = value.normalized;
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
			Input = value.Get<Vector2>();
		}

		[UsedImplicitly]
		private void OnLook(InputValue value)
		{
			_lookDir = value.Get<Vector2>().normalized;
		}

		[UsedImplicitly]
		private void OnControlsChanged(PlayerInput playerInput)
		{
			this.Log(playerInput.currentControlScheme);
			_hasMouse = (playerInput.currentControlScheme == "Keyboard&Mouse");
		}

		private void FixedUpdate()
		{
			ChangeLookDirection();
			ApplyMovement();
		}

		private void ChangeLookDirection()
		{
			if (_hasMouse)
			{
			 	Vector3 mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

				Vector2 playerMouse = mousePos - transform.position;
				_lookDir = playerMouse.normalized;
			}

			// float angle = Mathf.Atan2(.y, lookDir.x);
			// transform.rotation = Quaternion.LookRotation(lookDir);
			transform.up = _lookDir;
		}

		private void ApplyMovement()
		{
			Vector2 vel = Input * speed;
			_rb.velocity = vel;
		}
	}
}