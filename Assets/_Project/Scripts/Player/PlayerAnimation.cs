using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EpicGameJam.Player
{
    public static class PlayerAnimation
    {
        // ReSharper disable ConvertToConstant.Global
        public static readonly string IdleUp    = "PlayerIdleUp";
        public static readonly string IdleDown  = "PlayerIdleDown";
        public static readonly string IdleLeft  = "PlayerIdleLeft";
        public static readonly string IdleRight = "PlayerIdleRight";
		
        public static readonly string WalkUp    = "PlayerWalkUp";
        public static readonly string WalkDown  = "PlayerWalkDown";
        public static readonly string WalkLeft  = "PlayerWalkLeft";
        public static readonly string WalkRight = "PlayerWalkRight";

        public static readonly string AttackDown  = "AttackDown";
        public static readonly string AttackLeft  = "AttackLeft";
        public static readonly string AttackRight = "AttackRight";
        public static readonly string AttackUp    = "AttackUp";
    }
}
