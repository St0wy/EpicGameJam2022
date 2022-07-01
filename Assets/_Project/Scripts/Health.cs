using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
	public class Health : MonoBehaviour
	{
		public static Health health_;
		public delegate void HurtCallback(int healthPoints);

		[SerializeField] private int _maxHealthPoints = 10;
		[SerializeField] private bool _destroyWhenKilled = true;
		[SerializeField] private float _destroyTime;
		
		private int _healthPoints;

		public HurtCallback OnHurt { get; set; }
		public bool IsAlive { get; private set; }

		public int HealthPoints
		{
			get => _healthPoints;
			private set
			{
				_healthPoints = value;
				if (_healthPoints > _maxHealthPoints)
					_healthPoints = _maxHealthPoints;
			}
		}

		private void Awake()
		{
			HealthPoints = _maxHealthPoints;
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

			if (!IsAlive && _destroyWhenKilled)
			{
				Destroy(gameObject, _destroyTime);
			}
		}
	}
}