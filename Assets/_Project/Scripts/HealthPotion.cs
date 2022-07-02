using UnityEngine;

namespace EpicGameJam
{
	public class HealthPotion : MonoBehaviour
	{
		[SerializeField] private int healAmount = 2;

		private void OnTriggerEnter2D(Collider2D other) //health the player
		{
			if (other.name != "Player") return;

			if (other.TryGetComponent(out Health health))
			{
				health.HealCharacter(healAmount);
			}

			Destroy(gameObject);
		}
	}
}