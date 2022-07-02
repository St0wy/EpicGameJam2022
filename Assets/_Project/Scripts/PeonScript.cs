using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PeonScript : MonoBehaviour
	{
		[FormerlySerializedAs("_speed")] [FormerlySerializedAs("speed_")] [SerializeField]
		private float speed = 2.0f;

		[SerializeField] private float distanceToActivate = 1.0f;
		[SerializeField] private Transform playerTrans;

		private Rigidbody2D _rb;
		private Vector2 _movement;
		private bool _followPlayer = false;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			Vector2 peonToTarget = playerTrans.position - transform.position;

			if (!(peonToTarget.magnitude < distanceToActivate)) return;

			Vector2 vel = peonToTarget.normalized * speed;
			_rb.velocity = vel;

			_followPlayer = true;
		}
	}
}