using UnityEngine;


namespace RollerBall.Player
{
    public class PlayerJoystick : Player
    {
        [SerializeField] private GameObject joystick;
        private FixedJoystick joystickScript;

        // Start is called before the first frame update
        public override void Start()
        {
            joystick.SetActive(true);
            joystickScript = joystick.GetComponent<FixedJoystick>();
            base.Start();
        }
        private void Update()
        {
            float horizontalMovement = joystickScript.Horizontal;
            float verticalMovement = joystickScript.Vertical;
            Move(verticalMovement, horizontalMovement);
        }

    }
}
