using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class TrapManager : InteractableManager, IEnumerable
    {
        private List<InteractableObject> traps = new List<InteractableObject>();
        public static event Action<int> OnTrapsCountChanged;

        public InteractableObject this[int index]
        {
            get
            {
                return traps[index];
            }
        }

        private void SortTraps(TrapObject trapInstance)
        {
            traps.Add(trapInstance);
            OnTrapsCountChanged?.Invoke(Count());
            trapInstance.OnInteract += delegate (GameObject obj)
            {
                traps.Remove(trapInstance);
                OnTrapsCountChanged?.Invoke(Count());
            };
        }
        public override InteractableObject InstantiateObject()
        {
            TrapObject objectInstance = (TrapObject)base.InstantiateObject();
            objectInstance.Manager = this;
            SortTraps(objectInstance);
            return objectInstance;
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i < traps.Count)
            {
                yield return traps[i];
                i += 1;
            }

        }

        public override int Count()
        {
            return traps.Count;
        }
        private void OnDestroy()
        {
            OnTrapsCountChanged = null;
        }
    }
}

