using System;
using UnityEngine;

namespace EpicGameJam.Player
{
	[RequireComponent(typeof(PlayerMovement))]
	[RequireComponent(typeof(MovementState))]
	[RequireComponent(typeof(Animator))]
	public class PlayerAnimationBehaviour : MonoBehaviour
	{
		
		private PlayerMovement _playerMovement;
		private Animator _animator;
		private SwordBehaviour _swB;
		private string _currentAnim;
		private MovementState _movS;

		private void Awake()
		{
			_playerMovement = GetComponent<PlayerMovement>();
			_animator = GetComponent<Animator>();
			_swB = GetComponent<SwordBehaviour>();
		}

		private void Update()
		{
			HandleNoAction();
		}

		private void HandleNoAction()
		{
			switch (_playerMovement.MovementState)
			{
				case MovementState.Idle:
					HandleIdleNoActions();
					
					break;
				case MovementState.Walk:
					HandleMovingNoAction();
					break;
				case MovementState.Attacking:
					HandleAttack();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			
		}
		private void HandleAttack()
		{
			switch (_playerMovement.Direction)
			{
				case Direction.Up:
					SetAnimationState(PlayerAnimation.AttackUp);
					break;
				case Direction.Down:
					SetAnimationState(PlayerAnimation.AttackDown);
					break;
				case Direction.Left:
					SetAnimationState(PlayerAnimation.AttackLeft);
					break;
				case Direction.Right:
					SetAnimationState(PlayerAnimation.AttackRight);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}


			
		}
		private void HandleMovingNoAction()
		{
			switch (_playerMovement.Direction)
				{
					case Direction.Up:
						SetAnimationState(PlayerAnimation.WalkUp);
						break;
					case Direction.Down:
						SetAnimationState(PlayerAnimation.WalkDown);
						break;
					case Direction.Left:
						SetAnimationState(PlayerAnimation.WalkLeft);
						break;
					case Direction.Right:
						SetAnimationState(PlayerAnimation.WalkRight);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			
			
		}

		private void HandleIdleNoActions()
		{
			switch (_playerMovement.Direction)
			{
				case Direction.Up:
					SetAnimationState(PlayerAnimation.IdleUp);
					break;
				case Direction.Down:
					SetAnimationState(PlayerAnimation.IdleDown);
					break;
				case Direction.Left:
					SetAnimationState(PlayerAnimation.IdleLeft);
					break;
				case Direction.Right:
					SetAnimationState(PlayerAnimation.IdleRight);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void SetAnimationState(string newAnimation)
		{
			if (_currentAnim == newAnimation) return;
			_animator.Play(newAnimation);
			_currentAnim = newAnimation;
		}
	
    }
}
