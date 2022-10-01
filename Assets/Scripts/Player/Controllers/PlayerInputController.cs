using RollerBall.Units;

namespace RollerBall.Controllers
{
    public class PlayerInputController : UnitInputController
    {
        private void Awake()
        {
            Player.OnInitialize += AttachController;
        }

    }

}
