using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall
{
    
    public interface IMovable
    {
        void Move(float verticalMove,float horizontalMove);
    }
}

