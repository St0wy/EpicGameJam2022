using System;
using System.Collections;
using System.Collections.Generic;
using EpicGameJam.Player;
using UnityEngine;

namespace EpicGameJam
{
    public class Animation : MonoBehaviour
    {
        private enum State
        {
            NONE,
            WALK,
            IDLE
        }
         private Animator _animator;

         private Transform _playerTransform;

         private bool _isFacingRight = false;

         private State _currentState;
        // Start is called before the first frame update
        void Start()
        {
            _animator.GetComponent<Animator>();
            _playerTransform.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void FixedUpdate()
        {
            switch (_currentState)
            {
                case State.IDLE:
                    //todo implement white player moovement
                    break;
                case State.WALK:
                //todo implement white player moovement
                break;
            }
        }

        private void Flip()
        {
            Vector3 newScale = _playerTransform.transform.localScale;
            newScale.x *= -1;   
            _playerTransform.transform.localScale = newScale;
            _isFacingRight = !_isFacingRight;
        }
        
        private void ChangeState(State state)
        {
            switch (state)
            {
                case State.WALK:
                    _animator.Play("WalkRight");
                    break;
                case State.IDLE:
                    //todo create anim for player to idle
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }

            _currentState = state;
        }
    }
}
