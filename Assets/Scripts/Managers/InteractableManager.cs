using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;
using RollerBall.Exceptions;

namespace RollerBall.Interactable
{

    public class InteractableManager : MonoBehaviour, ICountable
    {
        [SerializeField] private InteractableObject[] objectPrefabs;
        [SerializeField] private List<Transform> objectPositions;
        [SerializeField] private int objectCount;


        private void Start()
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

        public virtual InteractableObject InstantiateObject()
        {
            Transform randomObjectPosition;
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
            catch(ListIsEmptyException e)
            {
                LogWarning(e);
                return null;
            }
            
            InteractableObject objectInstance = Instantiate(randomObjectPrefab, randomObjectPosition.position, Quaternion.identity) as InteractableObject;
            objectPositions.Remove(randomObjectPosition);
            objectInstance.Manager = this;
            return objectInstance;
        }

        public virtual int Count()
        {
            return 0;
        }
    }
}
