﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(PlayerMovement))]
	public class SwordBehaviour : MonoBehaviour
	{
		[SerializeField] private BoxCollider2D box;
		[SerializeField] private Animator swordAnimator;
		[FormerlySerializedAs("sword")] [SerializeField]
		private Transform swordRotationPoint;
		[SerializeField] private int damage;

		private bool _isAttacking;
		private readonly Collider2D[] _colliders = new Collider2D[15];
		private PlayerMovement _pm;

		private void Awake()
		{
			_pm = GetComponent<PlayerMovement>();
		}

		private void FixedUpdate()
		{
			if (_isAttacking)
			{
				HandleAttack();
			}
		}

		private void HandleAttack()
		{
			int amount = box.GetContacts(_colliders);

			for (int i = 0; i < amount; i++)
			{
				// Check that we are not hitting ourself
				if (_colliders[i].CompareTag(gameObject.tag)) continue;

				// Get the life component and hit if it exists
				if (_colliders[i].TryGetComponent(out Health health))
				{
					health.ReduceHealth(damage);
				}
			}
		}

		public float Attack()
		{
			float angle = Mathf.Atan2(_pm.LookDir.y, _pm.LookDir.x) * Mathf.Rad2Deg;
			angle -= 90f;
			swordRotationPoint.rotation = Quaternion.Euler(0, 0, angle);

			// Enable hit box and sword game object
			swordAnimator.gameObject.SetActive(true);
			_isAttacking = true;

			swordAnimator.Play(SwordAnimations.Attack);
			float attackDuration = swordAnimator.GetCurrentAnimatorStateInfo(0).length;

			StartCoroutine(StopAttackCoroutine(attackDuration));
			return attackDuration;
		}

		private IEnumerator StopAttackCoroutine(float timeToStop)
		{
			yield return new WaitForSeconds(timeToStop);
			StopAttack();
		}

		private void StopAttack()
		{
			_isAttacking = false;
			swordAnimator.gameObject.SetActive(false);
		}
	}
}