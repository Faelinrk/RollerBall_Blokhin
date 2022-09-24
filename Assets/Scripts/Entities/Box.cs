using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Entities
{
    public class Box : MonoBehaviour, IInteractable, IKillable
    {
        private Vector3 startPosition;
        private void Start()
        {
            startPosition = transform.position;
        }
        public GameObject Interact(GameObject interactor)
        {
            return this.gameObject;
        }

        public void Kill()
        {
            transform.position = startPosition;
        }
    }
}

