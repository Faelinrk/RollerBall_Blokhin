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
    }
}

