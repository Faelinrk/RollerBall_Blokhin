using RollerBall.Units;

namespace RollerBall.Controllers
{
    public class PlayerJoystickController : UnitJoystickController
    {
        private void Awake()
        {
            Player.OnInitialize += AttachController;
        }
    }

}
