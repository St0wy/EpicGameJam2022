using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam.Player
{
	public class SwordBehaviour : MonoBehaviour
	{
		[SerializeField] private BoxCollider2D box;
		[SerializeField] private Animator swordAnimator;
		[FormerlySerializedAs("sword")] [SerializeField]
		private Transform swordRotationPoint;
		[SerializeField] private int damage;

		private bool _isAttacking;

		private readonly Collider2D[] _colliders = new Collider2D[15];

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
			float angle = transform.rotation.z;
			// swordRotationPoint.rotation = Quaternion.Euler(0, 0, angle);

			// Enable hit box and sword game object
			swordAnimator.gameObject.SetActive(true);
			_isAttacking = true;
			// swordRotationPoint.transform.rotation = Quaternion.identity;

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