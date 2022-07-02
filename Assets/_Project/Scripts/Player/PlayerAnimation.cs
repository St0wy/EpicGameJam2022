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
         private float _deadZone = 0.5f;
         
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
                    if (Mathf.Abs(Direction.Right) > _deadZone && _isFacingRight)
                    {
                        _animator.Play("WalkRight");
                    }
                    //todo implement white player moovement
                    break;
                case MovementState.Walk:
                    if (Mathf.Abs(Direction.Left) > _deadZone && _isFacingRight)
                    {
                        _animator.Play("IdleAnim");
                    }
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
