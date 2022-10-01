using UnityEngine;

namespace RollerBall.Controllers
{
    public class UnitInputController : UnitController
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        protected override void Update()
        {
            verticalMove = Input.GetAxis(Vertical);
            horizontalMove = Input.GetAxis(Horizontal);
            base.Update();
        }
    }
}
