using JetBrains.Annotations;
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

		private Vector2 input;
		private Rigidbody2D rb;

		private Vector2 Input
		{
			get => input;
			set => input = value.normalized;
		}

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		[UsedImplicitly]
		private void OnMove(InputValue value)
		{
			//Get the directional value
			Input = value.Get<Vector2>();
		}

		private void FixedUpdate()
		{
			ApplyMovement();
		}

		private void ApplyMovement()
		{
			Vector2 vel = Input * speed;
			rb.velocity = vel;
		}
	}
}