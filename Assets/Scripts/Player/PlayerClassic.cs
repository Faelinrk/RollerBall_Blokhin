using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Player
{
    public class PlayerClassic : Player
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        private void Update()
        {
            Move(Input.GetAxis(Vertical), Input.GetAxis(Horizontal));
        }
    }
}
