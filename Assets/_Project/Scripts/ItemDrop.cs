using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace EpicGameJam
{
	[RequireComponent(typeof(Health))]
	public class ItemDrop : MonoBehaviour
	{
		[FormerlySerializedAs("potionDrop")] [SerializeField]
		private GameObject itemToDrop;
		[SerializeField] private float dropChance;

		private Health _health;

		private void Awake()
		{
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnDeath += DropPotion;
		}

		private void OnDisable()
		{
			_health.OnDeath -= DropPotion;
		}

		private void DropPotion()
		{
			if (Random.Range(0f, 1f) <= dropChance)
			{
				// Spawn potion
				Instantiate(itemToDrop, transform.position, Quaternion.identity);
			}

			Destroy(gameObject);
		}
	}
}