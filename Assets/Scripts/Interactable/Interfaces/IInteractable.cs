using System;
using UnityEngine;

namespace RollerBall
{
    public interface IInteractable
    {
        GameObject Interact(GameObject interactor);// return gameobject with interaction interface
    }

}

