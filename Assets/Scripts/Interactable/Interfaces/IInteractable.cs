using System;

namespace RollerBall
{
    public interface IInteractable
    {
        void Interact();
        void AttachEffect(ref Action action);
    }

}

