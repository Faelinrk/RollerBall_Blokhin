using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollerBall.Interactable;

namespace RollerBall.Units
{
    public class PlayerSphere : MonoBehaviour, IInteractable
    {
        [SerializeField] GameObject interactorObj;
        public GameObject Interact(GameObject obj)
        {
            return interactorObj;
        }
    }
}

