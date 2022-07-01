using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
    public class PeonScript : MonoBehaviour
    {
        [SerializeField] private float life_ = 10.0f;
        [SerializeField] private float speed_ = 2.0f;
        [SerializeField] private Rigidbody2D playerRigidbody2d_;
        private Vector2 movement_;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void CalculatePath(Rigidbody2D bodyPlayer)
        {
            if (bodyPlayer.CompareTag("Player"))
            {
                movement_.x *= speed_;
                movement_.y *= speed_;
            }
        }
    }
}
