using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Serialization;

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

        [FormerlySerializedAs("bodyPlayer_")] [SerializeField]
        private Rigidbody2D _bodyPlayer;

        [SerializeField] private float distanceToActivate = 10;
        [SerializeField] private Transform playerTrans;
        private Vector2 movement_;

        private void Update()
        {
            Vector2 peonToTarget = playerTrans.position - transform.position;
            
            if (!(peonToTarget.magnitude < distanceToActivate)) return;
            
            var movementVec = peonToTarget.normalized * _speed;
            transform.Translate(movementVec);
            // TODO: replace translate by RigidBody
        }
    }
}