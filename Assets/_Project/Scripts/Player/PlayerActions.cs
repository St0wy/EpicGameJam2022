using System;
using JetBrains.Annotations;
using StowyTools.Logger;
using UnityEngine;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(SwordBehaviour), typeof(PlayerMovement))]
	public class PlayerActions : MonoBehaviour
	{
		private SwordBehaviour _swordBehaviour;
		// private PlayerMovement _playerMovement;

		private void Awake()
		{
			_swordBehaviour = GetComponent<SwordBehaviour>();
			// _playerMovement = GetComponent<PlayerMovement>();
		}

		[UsedImplicitly]
		private void OnAttack()
		{
			this.Log("Attack");
			_swordBehaviour.Attack();
		}
	}
}