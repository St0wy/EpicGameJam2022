using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam
{
	public enum PeonState
	{
		NONE,
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

		[SerializeField] private Vector2 _velocity;
		[FormerlySerializedAs("playerTrans")] [SerializeField]
		private Transform playerTransform;
		[SerializeField] private float distanceToActivate = 10f;
		[SerializeField] private float distanceToAttack = 1.5f;
		[SerializeField] private float timeToAttack = 0.5f;
		[SerializeField] private float timeToWalkOnPlayer = 0.5f;
		[SerializeField] private int damage = 1;
		[SerializeField] private Health _playerHealth;

		//animator
		private Animator _peonAnim;
		//rigibody
		private Rigidbody2D _rb;
		private float _attackTimer;
		
		//state
		private PeonState _state;

		private bool _isFollowing = false;
		private Health _health;


		private void Awake()
		{
			_health = FindObjectOfType<Health>();
			_rb = GetComponent<Rigidbody2D>();
			_peonAnim = GetComponent<Animator>();
		}

		private void Update()
		{
			if (_state is PeonState.Attacking or PeonState.ChargingAttack)
			{
				_velocity = Vector2.zero;
				_isFollowing = false;
			}
			
			Vector2 peonToTarget = playerTransform.position - transform.position;
			float distance = peonToTarget.magnitude;
				
			MoveToTarget(peonToTarget);
			
			_velocity = Vector2.zero;
				
			if (!(distance < distanceToAttack)) return;
			_state = PeonState.ChargingAttack;
			ReturnMainMenuForPlayer();
		}

		private void MoveToTarget(Vector2 dir)
		{
			 _velocity = dir.normalized * speed;
			_rb.velocity = _velocity;
			_isFollowing = true;
			_state = PeonState.WalkingToTarget;
		}
		
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				_health.ReduceHealth(damage);
			}
		}

		private void ReturnMainMenuForPlayer()
		{
			if (!_playerHealth.IsAlive)
			{
				_health.ReturnToMainMenu();
			}
		}
	}
}