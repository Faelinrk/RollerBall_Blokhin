using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Player
{
    
    public interface IPlayerMovement
    {
        void Move(float verticalMove,float horizontalMove);
    }
}

