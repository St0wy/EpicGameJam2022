﻿using JetBrains.Annotations;
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

		[SerializeField]
		private bool _isUsingMouse;
		[SerializeField]
		private bool _isUsingRStick;
		[SerializeField]
		private bool _isMoving;

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

			if (!_lookDir.IsApproxZero())
				transform.up = _lookDir;
		}

		private void ApplyMovement()
		{
			Vector2 vel = Input * speed;
			_rb.velocity = vel;
		}
	}
}