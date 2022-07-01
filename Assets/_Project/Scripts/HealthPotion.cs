using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
    public class HealthPotion : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) //health the player
        {
            if (other.name == "Player")
            {
                
                    Health.health_.HealCharacter(2);
                
               
                Destroy(gameObject);
            }
        }
    }
}
