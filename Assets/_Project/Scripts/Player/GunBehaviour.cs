using System;
using JetBrains.Annotations;
using UnityEngine;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(PlayerMovement))]
	public class GunBehaviour : MonoBehaviour
	{
		[SerializeField] private Transform gunPivot;
		[SerializeField] private Transform shootPoint;
		[SerializeField] private GameObject bulletPrefab;

		private PlayerMovement _pm;

		private void Awake()
		{
			_pm = GetComponent<PlayerMovement>();
		}

		private void Update()
		{
			gunPivot.transform.up = _pm.LookDir;
		}

		[UsedImplicitly]
		private void OnFire()
		{
			GameObject goBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
			var bullet = goBullet.GetComponent<BulletBehaviour>();
			bullet.Shoot(_pm.LookDir);
		}
	}
}