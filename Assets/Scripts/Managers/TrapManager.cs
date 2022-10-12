using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class TrapManager : InteractableManager, IEnumerable
    {
        private List<InteractableObject> traps = new List<InteractableObject>();
        public static event Action<int> OnTrapsCountChanged;

        #region Data
        private List<Vector3> trapsPositions = new List<Vector3>();
        private const string SavingPath = "Traps";

        public override void SaveData()
        {
            trapsPositions = traps.Select(t => t.transform.position).ToList();
            dataSo.InitializeSaver(SavingPath, trapsPositions);
            dataSo.SaveData();
        }

        public override void LoadData()
        {
            objectPositions = dataSo.LoadData(SavingPath);
            objectCount = objectPositions.Count;
        }
        #endregion

        private void SortTraps(TrapObject trapInstance)
        {
            traps.Add(trapInstance);
            OnTrapsCountChanged?.Invoke(Count());
            trapInstance.OnInteract += delegate (GameObject obj)
            {
                traps.Remove(trapInstance);
                OnTrapsCountChanged?.Invoke(Count());
            };
            if (Count() >= objectCount)
            {
                SaveData(); // save if all traps set
            }
        }

        public override InteractableObject InstantiateObject()
        {
            TrapObject objectInstance = (TrapObject)base.InstantiateObject();
            objectInstance.Manager = this;
            SortTraps(objectInstance);
            return objectInstance;
        }
        private void OnDestroy()
        {
            OnTrapsCountChanged = null;
        }

        #region Interfaces
        public InteractableObject this[int index]
        {
            get
            {
                return traps[index];
            }
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
        #endregion

    }
}

