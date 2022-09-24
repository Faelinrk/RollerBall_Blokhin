using System;
using UnityEngine;

namespace RollerBall.Interactable
{
    public interface IEffectable : IInteractable
    {
        void AttachEffect(ref Action<GameObject> onInteract);
    }
}

