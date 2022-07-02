using UnityEngine;

namespace EpicGameJam
{
	public class HealthPotion : MonoBehaviour
	{
		[SerializeField] private int healAmount = 2;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			
			if (collision.gameObject.CompareTag("Player"))
			{
				Health health = collision.gameObject.GetComponent<Health>();
				if (health)
				{
					health.HealCharacter(healAmount);
					Destroy(gameObject);
				}
				
			}
			
		}
	}
}