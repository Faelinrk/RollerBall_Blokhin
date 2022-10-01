using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Controllers
{
    public class UnitController : MonoBehaviour
    {
        protected IMovable unit;
        protected float verticalMove;
        protected float horizontalMove;

        protected virtual void Update()
        {
            if (unit!=null)
            unit.Move(verticalMove,horizontalMove);
        }
        protected void AttachController(IMovable moveObj)
        {
            this.unit = moveObj;
        }
    }

}
