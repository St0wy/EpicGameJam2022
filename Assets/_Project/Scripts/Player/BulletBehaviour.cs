using System;
using UnityEngine;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BulletBehaviour : MonoBehaviour
	{
		[SerializeField] private float speed = 5f;
		[SerializeField] private float damage = 2;

		private Rigidbody2D _rb;
		private Vector2 _direction;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
		}
		
		private void FixedUpdate()
		{
			_rb.velocity = _direction * speed;
		}

		public void Shoot(Vector2 direction)
		{
			_direction = direction;
		}
	}
}