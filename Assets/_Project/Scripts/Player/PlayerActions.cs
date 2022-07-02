using JetBrains.Annotations;
using UnityEngine;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(SwordBehaviour), typeof(PlayerMovement))]
	public class PlayerActions : MonoBehaviour
	{
		private SwordBehaviour _swordBehaviour;

		private void Awake()
		{
			_swordBehaviour = GetComponent<SwordBehaviour>();
		}

		[UsedImplicitly]
		private void OnAttack()
		{
			_swordBehaviour.Attack();
		}
	}
}