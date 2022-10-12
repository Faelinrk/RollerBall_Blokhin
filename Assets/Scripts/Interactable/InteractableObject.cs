using System;
using System.Collections.Generic;
using UnityEngine;
using RollerBall.Data;

namespace RollerBall.Interactable
{
    [Serializable]
    public class InteractableObject : MonoBehaviour, IEffectable, ICloneable
    {
        public event Action<GameObject> OnInteract;

        public InteractableManager Manager { get; set; }

        private void Start()
        {
            AttachEffect(ref OnInteract);
        }
        public virtual GameObject Interact(GameObject interactor)
        {
            OnInteract?.Invoke(interactor);
            Destroy(gameObject);
            return gameObject;
        }
        private void OnDestroy()
        {
            OnInteract = null;
        }
        public virtual void AttachEffect(ref Action<GameObject> action)
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            GameObject interactorObj;
            if (other.TryGetComponent<IInteractable>(out IInteractable interactor))
            {
                interactorObj = interactor.Interact(gameObject);
                Debug.Log($"{interactorObj.name} interacted with {gameObject.name}");
                Interact(interactorObj);
            }


        }

        public object Clone()
        {
            return Manager.InstantiateObject();
        }

    }
}

