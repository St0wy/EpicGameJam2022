using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
    public class Health : MonoBehaviour
    {
	    public static Health health_;
       public delegate void HurtCallback(int healthPoints);

		
		[SerializeField] private int maxHealthPoints = 10;
		[SerializeField] private int potionHeal= 2;

		[SerializeField] private bool destroyWhenKilled = true;

		
		[SerializeField] private float destroyTime;

		[Tooltip("Field indicating whether the object has invulnerability frames after getting hit.")]
		[SerializeField] private bool hasIFrames;

	
		[Tooltip("The duration of the invulnerability.")]
		[SerializeField] private float iFramesDuration = 0.5f;

		
		[SerializeField] private float iFrameTimer;

		

		public HurtCallback OnHurt { get; set; }
		public bool IsAlive { get; private set; }
		public int HealthPoints { get; private set; }
		
		public bool isHealed { get; private set; }
		public bool IsInIFrame => hasIFrames && iFrameTimer > 0;

		private void Awake()
		{
			HealthPoints = maxHealthPoints;
			IsAlive = true;
		}

		private void Update()
		{
			// Check if IFrames are enabled
			if (!hasIFrames) return;
			
			// Update the timer if we are in an IFrame
			if (IsInIFrame)
			{
				iFrameTimer -= Time.deltaTime;
			}

			if (isHealed)
			{
				HealCharacter(potionHeal);
			}
		}

	
		public void HealCharacter(int heal)
		{
			
			HealthPoints += heal;
			CheckOverheal();
		}
		private void CheckOverheal()
		{
			if (HealthPoints > maxHealthPoints)
			{
				HealthPoints = maxHealthPoints;
			}
		}
		
		public void ReduceHealth(int ammount)
		{
			HealthPoints -= ammount;

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
