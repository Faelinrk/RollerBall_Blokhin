using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;
using RollerBall.Exceptions;
using RollerBall.Data;

namespace RollerBall.Interactable
{

    public abstract class InteractableManager : MonoBehaviour, ICountable, ISavable<List<Vector3>>
    {
        [SerializeField] private InteractableObject[] objectPrefabs;
        [SerializeField] protected List<Transform> objectTransforms;
        protected List<Vector3> objectPositions = new List<Vector3>();
        [SerializeField] protected int objectCount;
        [SerializeField] protected PositionDataSO dataSo;

        private void Start()
        {
            foreach(var tr in objectTransforms)
            {
                objectPositions.Add(tr.position);
            }
        }

        public virtual InteractableObject InstantiateObject()
        {
            Vector3 randomObjectPosition;
            InteractableObject randomObjectPrefab;
            try
            {
                if (objectPositions.Count <= 0) throw new Exception("Not enough interactable object positions");
                randomObjectPosition = objectPositions[UnityEngine.Random.Range(0, objectPositions.Count - 1)];
            }
            catch (ListIsEmptyException e)
            {
                LogWarning(e);
                return null;
            }
            try
            {
                if (objectPrefabs.Length <= 0) throw new Exception("List of interactable objects is empty");
                randomObjectPrefab = objectPrefabs[UnityEngine.Random.Range(0, objectPrefabs.Length - 1)];
            }
            catch (ListIsEmptyException e)
            {
                LogWarning(e);
                return null;
            }

            InteractableObject objectInstance = Instantiate(randomObjectPrefab, randomObjectPosition, Quaternion.identity) as InteractableObject;
            objectPositions.Remove(randomObjectPosition);
            objectInstance.Manager = this;
            return objectInstance;
        }

        public void InstantiateFromLoad()
        {
            LoadData();
            InstantiateObjects();
        }
        public void Instantiate()
        {
            InstantiateObjects();
        }

        private void InstantiateObjects()
        {
            for (int i = 0; i < objectCount; i++)
            {
                InstantiateObject();
            }
        }

        public virtual int Count()
        {
            return 0;
        }

        public virtual void SaveData()
        {
        }

        public virtual void LoadData()
        {
        }
    }
}
