using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class InteractableObject : MonoBehaviour, IEffectable, ICloneable
    {
        protected event Action<GameObject> onInteract;
        public InteractableManager Manager { get; set; }
        private void Start()
        {
            AttachEffect(ref onInteract);
        }
        public virtual GameObject Interact(GameObject interactor)
        {
            onInteract?.Invoke(interactor);
            Destroy(gameObject);
            return gameObject;
        }
        private void OnDestroy()
        {
            onInteract = null;
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
        public void AddToList(List<InteractableObject> list)
        {
            list.Add(this);
            onInteract += delegate (GameObject obj)
            {
                list.Remove(this);
                Log("Object Removed from list");
            };
        }
        public object Clone()
        {
            return Manager.InstantiateObject();
        }

    }
}

