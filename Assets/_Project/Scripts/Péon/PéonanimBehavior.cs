using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
    public class PéonanimBehavior : MonoBehaviour
    {
        [SerializeField]private Animator _peonAnim;
        private Transform _peonTrans;
        private PeonState _currentState;
        private Vector2 _dir;
        private PeonScript _peonScript;
        // Start is called before the first frame update
        private void Start()
        {
            _currentState = PeonState.Idle;
        }

        // Update is called once per frame
        void Update()
        {
            switch (_currentState)
            {
                case PeonState.WalkingToTarget:
                   ChangeState(PeonState.WalkingToTarget);
                   break;
            }
        }

        private void ChangeState(PeonState state)
        {
            switch (state)
            {
                case PeonState.Idle:
                    break;
                case PeonState.WalkingToTarget:
                    _peonAnim.Play("peonWalk");
                    break;
                case PeonState.Attacking:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
            _currentState = state;
        }
    }
}
