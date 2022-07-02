using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace EpicGameJam.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private int damage = 2;
        private float _destroyTime = 3f;
        private Rigidbody2D _rb;
        private Vector2 _direction;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, _destroyTime);
        }

        private void FixedUpdate()
        {
            _rb.velocity = _direction * speed;
        }

        public void Shoot(Vector2 direction)
        {
            _direction = direction;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) return;
            
            Health health = collision.gameObject.GetComponent<Health>();
            if (health)
            {
                health.ReduceHealth(damage);
            }
            
            Destroy(gameObject);
        }
    }
}