using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

namespace RollerBall.Interactable
{
    public class TrapObject : InteractableObject
    {
        [SerializeField] private float speedDownPower = -5;
        [SerializeField] private float damage = 5;
        public override void AttachEffect(ref Action<GameObject> action)
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
        void Kill(GameObject obj)
        {
            if (obj.TryGetComponent(out IKillable initiator))
                initiator.Kill();
        }
        void SpeedDown(GameObject obj)
        {
            if (obj.TryGetComponent(out IBoostable initiator))
                initiator.Boost(speedDownPower);
            else Kill(obj);
        }
        void DealDamage(GameObject obj)
        {
            if (obj.TryGetComponent(out IDamageble initiator))
                initiator.Damage(damage);
            else Kill(obj);
        }
        
    }
}

