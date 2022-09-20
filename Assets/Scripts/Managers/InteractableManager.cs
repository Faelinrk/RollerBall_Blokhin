using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{

    public class InteractableManager : MonoBehaviour
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
            try
            {
                if (objectPositions.Count <= 0) throw new Exception("Not enough interactable object positions");
                randomObjectPosition = objectPositions[UnityEngine.Random.Range(0, objectPositions.Count - 1)];
            }
            catch (Exception e)
            {
                LogWarning("Список позиций для объектов пуст");
                return null;
            }
            InteractableObject randomObjectPrefab = objectPrefabs[UnityEngine.Random.Range(0, objectPrefabs.Length - 1)];
            InteractableObject objectInstance = Instantiate(randomObjectPrefab, randomObjectPosition.position, Quaternion.identity) as InteractableObject;
            objectPositions.Remove(randomObjectPosition);
            objectInstance.Manager = this;
            return objectInstance;
        }
    }
}
