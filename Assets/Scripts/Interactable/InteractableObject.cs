using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class InteractableObject : MonoBehaviour, IInteractable, ICloneable
    {
        protected event Action onInteract;
        protected Player.Player initiator;
        private GameObject initiatorObject;
        public InteractableManager Manager { get; set; }
        private void Start()
        {
            initiator = FindObjectOfType<Player.Player>();
            initiatorObject = initiator.PlayerObject;
            AttachEffect(ref onInteract);
        }
        public virtual void Interact()
        {
            onInteract?.Invoke();
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            onInteract = null;
        }
        public virtual void AttachEffect(ref Action action)
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject== initiatorObject)
            {
                Interact();
            }
        }
        public void AddToList(List<InteractableObject> list)
        {
            list.Add(this);
            onInteract += delegate ()
            {
                list.Remove(this);
                Log("Объект удалён из списка");
            };
        }
        public object Clone()
        {
            return Manager.InstantiateObject();
        }
    }
}

