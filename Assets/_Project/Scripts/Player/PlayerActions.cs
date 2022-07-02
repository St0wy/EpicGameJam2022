using System;
using JetBrains.Annotations;
using StowyTools.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(SwordBehaviour), typeof(PlayerMovement))]
	public class PlayerActions : MonoBehaviour
	{
		private SwordBehaviour _swordBehaviour;
		private Camera _camera;

		private void Awake()
		{
			_swordBehaviour = GetComponent<SwordBehaviour>();
			_camera = Camera.main;
		}

		[UsedImplicitly]
		private void OnAttack()
		{
			Vector2 mousePos = Mouse.current.position.ReadValue();
			Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(mousePos);
			Vector2 toMouse = mouseWorldPos - transform.position;
			float angle = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
			angle -= 90f;
			_swordBehaviour.Attack(angle);
		}
	}
}