using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Interactable
{
    public class BonusManager : InteractableManager, IEnumerable, ICountable
    {
        private List<InteractableObject> positiveBonuses = new List<InteractableObject>();
        private List<InteractableObject> negativeBonuses = new List<InteractableObject>();
        public static event Action<int> OnBonusCountChanged;


        public InteractableObject this[int index]
        {
            get
            {
                if (index < positiveBonuses.Count)
                {
                    return positiveBonuses[index];
                }

                return negativeBonuses[index];
            }
        }

        private void SortBonuses(BonusObject bonusInstance)
        {
            if (bonusInstance.IsPositive)
            {
                positiveBonuses.Add(bonusInstance);
                bonusInstance.OnInteract += delegate (GameObject obj)
                {
                    positiveBonuses.Remove(bonusInstance);
                    OnBonusCountChanged?.Invoke(Count());
                };
            }
            else
            {
                negativeBonuses.Add(bonusInstance);
                bonusInstance.OnInteract += delegate (GameObject obj)
                {
                    negativeBonuses.Remove(bonusInstance);
                    OnBonusCountChanged?.Invoke(Count());
                };
            }
            OnBonusCountChanged?.Invoke(Count());
            

        }
        public override InteractableObject InstantiateObject()
        {
            BonusObject objectInstance = (BonusObject)base.InstantiateObject();
            SortBonuses(objectInstance);
            return objectInstance;
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i < positiveBonuses.Count)
            {
                yield return positiveBonuses[i];
                i += 1;
            }
            i = 0;
            while (i < negativeBonuses.Count)
            {
                yield return negativeBonuses[i];
                i += 1;
            }
        }
        public override int Count()
        {
            return positiveBonuses.Count + negativeBonuses.Count;
        }

        private void OnDestroy()
        {
            OnBonusCountChanged = null;
        }
    }
}

