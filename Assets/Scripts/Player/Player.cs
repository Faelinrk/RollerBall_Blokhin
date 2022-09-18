using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Player
{
    public abstract class Player : MonoBehaviour, IPlayerMovement
    {
        protected Rigidbody rb;
        [SerializeField] protected float speed = 5f;
        [SerializeField] private GameObject playerObject;
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
                rb.angularVelocity = new Vector3(verticalMove * speed, 0, -horizontalMove * speed);
                transform.position = playerObject.transform.position +  followOffset;
            }
            
        }
    }
}

