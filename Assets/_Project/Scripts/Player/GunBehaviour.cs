using System;
using UnityEngine;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(PlayerMovement))]
	public class GunBehaviour : MonoBehaviour
	{
		[SerializeField] private Transform gunPivot;

		private PlayerMovement _pm;

		private void Awake()
		{
			_pm = GetComponent<PlayerMovement>();
		}

		private void Update()
		{
			gunPivot.transform.up = _pm.LookDir;
		}
	}
}