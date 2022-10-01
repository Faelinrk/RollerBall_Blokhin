using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollerBall.Interactable
{
    public class BonusObject : InteractableObject
    {
        public bool IsPositive { get; private set; } = true;
        [SerializeField] private float healPower = 5;
        [SerializeField] private float boostPower = 5;
        [SerializeField] private float biggerPower = 5;
        [SerializeField] private float smallerPower = .5f;
        
        public override void AttachEffect(ref Action<GameObject> action)
        {
            int randomEffect = UnityEngine.Random.Range(1, 4);
            switch (randomEffect)
            {
                case 1:
                    action += Heal;
                    IsPositive = true;
                    break;
                case 2:
                    action += SpeedUp;
                    IsPositive = true;
                    break;
                case 3:
                    action += MakeSmaller;
                    IsPositive = false;
                    break;
                case 4:
                    action += MakeBigger;
                    IsPositive = false;
                    break;
            }
        }
        private void Heal(GameObject obj)
        {
            if (obj.TryGetComponent(out IHealable initiator))
                initiator.Heal(healPower);
        }
        private void SpeedUp(GameObject obj)
        {
            if (obj.TryGetComponent(out IBoostable initiator))
                initiator.Boost(boostPower);
        }
        private void MakeSmaller(GameObject obj)
        {
            if (obj.TryGetComponent(out IResizable initiator))
                initiator.Resize(smallerPower);
        }
        private void MakeBigger(GameObject obj)
        {
            if (obj.TryGetComponent(out IResizable initiator))
                initiator.Resize(biggerPower);
        }


    }
}

