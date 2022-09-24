using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

namespace RollerBall.Units
{
    public abstract class Player : MonoBehaviour, IMovable, IBoostable, IResizable, IDamageble, IHealable, IKillable
    {
        
        [SerializeField] protected float speed = 25f;
        [SerializeField] private float hp = 100;
        [SerializeField] private GameObject playerObject;
        private Vector3 followOffset;
        protected Rigidbody rb;

        #region Events
        public static event Action<float> OnHpChanged;
        public static event Action<float> OnSpeedChanged;
        private event Action onInitialize;
        #endregion

        #region Properties
        public GameObject PlayerObject => playerObject;
        public float Hp
        {
            get { return hp; }
            set
            {
                hp = value;
                OnHpChanged?.Invoke(hp);
            }
        }
        public float Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnSpeedChanged?.Invoke(speed);
            }
        }
        #endregion


        public virtual void Start()
        {
            rb = playerObject.GetComponent<Rigidbody>();
            followOffset = playerObject.transform.position - transform.position;
            playerObject.transform.SetParent(null);
        }

        #region Initialize
        private void Init() // Initialize for event call
        {
            Hp = hp;
            Speed = speed;
        }
        void OnEnable() // Scene event connection
        {
            onInitialize += Init;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode) // Initialize event call
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            onInitialize?.Invoke();
        }
        #endregion

        public void Move(float verticalMove,float horizontalMove)
        {
            if (verticalMove != 0 || horizontalMove != 0)
            {
                rb.angularVelocity = new Vector3(verticalMove * Speed, 0, -horizontalMove * Speed);
                rb.velocity = new Vector3(horizontalMove * Speed, rb.velocity.y, verticalMove * Speed);
                transform.position = playerObject.transform.position +  followOffset;
            }
            
        }

        #region InterfaceRealize
        public void Boost(float boost)
        {
            Speed += boost;
            Log("SpeedChanged");
        }

        public void Resize(float size)
        {
            Vector3 playerScale = PlayerObject.transform.localScale;
            PlayerObject.transform.localScale = new Vector3(playerScale.x * size, playerScale.y * size, playerScale.z * size);
            Log("SizeChanged");
        }

        public void Damage(float damage)
        {
            Hp -= damage;
            Log("Damaged");
        }

        public void Heal(float heal)
        {
            Hp += heal;
            Log("Heal");
        }

        public void Kill()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Log("You've beed killed");
        }
        #endregion
    }
}

