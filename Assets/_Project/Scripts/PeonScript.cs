using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam
{
	public enum PeonState
	{
		Idle,
		WalkingToTarget,
		ChargingAttack,
		Attacking,
	}

	[RequireComponent(typeof(Rigidbody2D))]
	public class PeonScript : MonoBehaviour
	{
		[FormerlySerializedAs("_speed")] [FormerlySerializedAs("speed_")] [SerializeField]
		private float speed = 2.0f;

		[FormerlySerializedAs("playerTrans")] [SerializeField]
		private Transform playerTransform;
		[SerializeField] private float distanceToActivate = 10f;
		[SerializeField] private float distanceToAttack = 1.5f;
		[SerializeField] private float timeToAttack = 0.5f;

		private Rigidbody2D _rb;
		private float _attackTimer;
		private PeonState _state;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if (_state is PeonState.Attacking or PeonState.ChargingAttack)
			{
				HandleAttack();
			}
			else
			{
				Vector2 peonToTarget = playerTransform.position - transform.position;
				float distance = peonToTarget.magnitude;

				if (!(distance < distanceToActivate)) return;

				MoveToTarget(peonToTarget);

				if (!(distance < distanceToAttack)) return;
				_state = PeonState.ChargingAttack;
			}
		}

		private void MoveToTarget(Vector2 dir)
		{
			Vector2 vel = dir.normalized * speed;
			_rb.velocity = vel;
		}

		private void HandleAttack()
		{
			// Charge son attaque (avec le timer et tout)

			// Attaque
		}
	}
}