using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollerBall.Data;
using System.Linq;

namespace RollerBall.Interactable
{
    public class BonusManager : InteractableManager, IEnumerable, ICountable
    {
        private List<InteractableObject> positiveBonuses = new List<InteractableObject>();
        private List<InteractableObject> negativeBonuses = new List<InteractableObject>();
        public static event Action<int> OnBonusCountChanged;

        #region Data
        private List<Vector3> bonusPositions;
        private const string SavingPath = "Bonuses";

        public override void SaveData()
        {
            bonusPositions = positiveBonuses.Select(t => t.transform.position)
                .Union(negativeBonuses.Select(t => t.transform.position))
                .ToList();
            dataSo.InitializeSaver(SavingPath, bonusPositions);
            dataSo.SaveData();
        }

        public override void LoadData()
        {
            objectPositions = dataSo.LoadData(SavingPath);
            objectCount = objectPositions.Count;
        }
        #endregion


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
            if (Count() >= objectCount)
            {
                SaveData(); // save if all bonuses set
            }
            OnBonusCountChanged?.Invoke(Count()); 
        }

        public override InteractableObject InstantiateObject()
        {
            BonusObject objectInstance = (BonusObject)base.InstantiateObject();
            SortBonuses(objectInstance);
            return objectInstance;
        }

        private void OnDestroy()
        {
            OnBonusCountChanged = null;
        }

        #region Interfaces
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
        public override int Count()
        {
            return positiveBonuses.Count + negativeBonuses.Count;
        }
        #endregion


    }
}

