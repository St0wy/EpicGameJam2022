using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using TreeEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

namespace EpicGameJam
{
    public class PeonScript : MonoBehaviour
    {
        [FormerlySerializedAs("life_")] [SerializeField]
        private float _life = 10.0f;

        [FormerlySerializedAs("speed_")] [SerializeField]
        private float _speed = 2.0f;
        
        [FormerlySerializedAs("bodyPeon_")] [FormerlySerializedAs("playerRigidbody2d_")] [SerializeField]
        private Rigidbody2D _bodyPeon;
        
        [SerializeField] private float distanceToActivate = 1.0f;
        [SerializeField] private Transform playerTrans;
        private Vector2 movement_;
        private bool followPlayer = false;
        
        private void Update()
        {
            Vector2 peonToTarget = playerTrans.position - transform.position;

            if (!(peonToTarget.magnitude < distanceToActivate)) return;
            
            var movementVec = peonToTarget.normalized * _speed;
            _bodyPeon.velocity = movementVec;
            followPlayer = true;
        }
    }
}