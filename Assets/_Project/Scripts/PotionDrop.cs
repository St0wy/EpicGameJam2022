using UnityEngine;
using Random = UnityEngine.Random;

namespace EpicGameJam
{
    public class PotionDrop : MonoBehaviour
    {
        public static PotionDrop potiondrop_;
        [SerializeField] GameObject potionDrop;
        [SerializeField] private float dropChance ;
        
        void DropPotion()
        {
            if ( Random.Range(0f, 1f) <= dropChance)
            {
                Instantiate(potionDrop, transform.position, Quaternion.identity); // spawn a dropped item

            }
            Destroy(gameObject);
            
        }

    }
}
