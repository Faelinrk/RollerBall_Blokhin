using UnityEngine;

namespace RollerBall.Player
{
    public abstract class Player : MonoBehaviour, IMovable
    {
        protected Rigidbody rb;
        [SerializeField] protected float speed = 25f;
        [SerializeField] private GameObject playerObject;
        [SerializeField] private int hp = 100;
        public GameObject PlayerObject => playerObject;
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private Vector3 followOffset;
        public virtual void Start()
        {
            rb = playerObject.GetComponent<Rigidbody>();
            followOffset = playerObject.transform.position - transform.position;
            playerObject.transform.SetParent(null); 
        }

        public void Move(float verticalMove,float horizontalMove)
        {
            if (verticalMove != 0 || horizontalMove != 0)
            {
                rb.angularVelocity = new Vector3(verticalMove * Speed, 0, -horizontalMove * Speed);
                transform.position = playerObject.transform.position +  followOffset;
            }
            
        }
    }
}

