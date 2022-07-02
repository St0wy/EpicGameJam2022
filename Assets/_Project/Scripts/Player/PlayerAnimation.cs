using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EpicGameJam.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
         private Animator _animator;
         private PlayerMovement _pm;
         private bool _isFacingRight = false;
         
        // Start is called before the first frame update
        public void Awake()
        {
            _animator = GetComponent<Animator>();
            _pm = GetComponent<PlayerMovement>();
        }

        private void FixedUpdate()
        { 
            switch (_pm.MovementState)
            {
                case MovementState.Idle:
                    //todo implement white player moovement
                    break;
                case MovementState.Walk:
                //todo implement white player moovement
                break;
            }
        }

        private void Flip()
        {
            Transform playerTransform = transform;
            Vector3 newScale = playerTransform.localScale;
            newScale.x *= -1;   
            playerTransform.localScale = newScale;
            _isFacingRight = !_isFacingRight;
        }
    }
}
