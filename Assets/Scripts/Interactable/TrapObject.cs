using System;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class TrapObject : InteractableObject
    {
        private int trapPower;
        public override void Interact()
        {
            base.Interact();
        }
        public override void AttachEffect(ref Action action)
        {
            int randomEffect = UnityEngine.Random.Range(1, 3);
            switch (randomEffect)
            {
                case 1:
                    action += Kill;
                    break;
                case 2:
                    action += SpeedDown;
                    break;
                case 3:
                    action += DealDamage;
                    break;
            }
        }
        void Kill()
        {
            SceneManager.LoadScene(0);
            Log("Вы были убиты");
        }
        void SpeedDown()
        {
            initiator.Speed -= trapPower;
            Log("SpeedDown");
        }
        void DealDamage()
        {
            initiator.Hp -= trapPower;
            Log("DamageDealed");
        }
        
    }
}

