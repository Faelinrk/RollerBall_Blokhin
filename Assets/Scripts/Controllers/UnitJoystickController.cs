using UnityEngine;


namespace RollerBall.Controllers
{
    public class UnitJoystickController : UnitController
    {
        [SerializeField] private GameObject joystick;
        private FixedJoystick joystickScript;

        // Start is called before the first frame update
        private void Start()
        {
            joystick.SetActive(true);
            joystickScript = joystick.GetComponent<FixedJoystick>();
        }
        protected override void Update()
        {
            horizontalMove = joystickScript.Horizontal;
            verticalMove = joystickScript.Vertical;
            base.Update();
        }

    }
}
