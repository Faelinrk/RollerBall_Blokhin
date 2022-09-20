using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class BonusObject : InteractableObject
    {
        public bool IsPositive { get; private set; } = true;
        private int bonusPower = 5;
        
        public override void Interact()
        {
            base.Interact();
        }
        
        public override void AttachEffect(ref Action action)
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
        private void Heal()
        {
            initiator.Hp += bonusPower;
            Log("Heal");
        }
        private void SpeedUp()
        {
            initiator.Speed += bonusPower;
            Log("SpeedUp");
        }
        private void MakeSmaller()
        {
            Vector3 playerScale = initiator.PlayerObject.transform.localScale;
            initiator.PlayerObject.transform.localScale = new UnityEngine.Vector3(playerScale.x / bonusPower, playerScale.y / bonusPower, playerScale.z / bonusPower);
            Log("MakeSmaller");
        }
        private void MakeBigger()
        {
            Vector3 playerScale = initiator.PlayerObject.transform.localScale;
            initiator.PlayerObject.transform.localScale = new UnityEngine.Vector3(playerScale.x * bonusPower, playerScale.y * bonusPower, playerScale.z * bonusPower);
            Log("MakeBigger");
        }

        
    }
}

