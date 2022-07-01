using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
	public class Health : MonoBehaviour
	{
		public delegate void HurtCallback(int healthPoints);

		[SerializeField] private int maxHealthPoints = 10;
		[SerializeField] private int potionHeal = 2;
		[SerializeField] private bool destroyWhenKilled = true;
		[SerializeField] private float destroyTime;
		
		private int healthPoints;

		public HurtCallback OnHurt { get; set; }
		public bool IsAlive { get; private set; }

		public int HealthPoints
		{
			get => healthPoints;
			private set
			{
				healthPoints = value;
				if (healthPoints > maxHealthPoints)
					healthPoints = maxHealthPoints;
			}
		}

		private void Awake()
		{
			HealthPoints = maxHealthPoints;
			IsAlive = true;
		}

		public void HealCharacter(int heal)
		{
			HealthPoints += heal;
		}

		public void ReduceHealth(int amount)
		{
			HealthPoints -= amount;

			if (HealthPoints <= 0)
			{
				IsAlive = false;
			}

			OnHurt?.Invoke(HealthPoints);

			if (!IsAlive && destroyWhenKilled)
			{
				Destroy(gameObject, destroyTime);
			}
		}
	}
}