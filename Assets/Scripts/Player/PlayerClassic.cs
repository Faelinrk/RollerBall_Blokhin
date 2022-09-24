using UnityEngine;

namespace RollerBall.Units
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
