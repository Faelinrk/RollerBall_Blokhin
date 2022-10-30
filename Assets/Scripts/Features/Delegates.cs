using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Delegates
{
    // Covariance. Here we can use child object of InteractableObject in delegate
    class InteractableObject{  }
    class BonusObject : InteractableObject { }

    class Delegates
    {
        //Covariance
        #region Covariance
        public delegate InteractableObject HandlerMethod();
        public static InteractableObject InteractableObjectHandler()
        {
            return null;
        }
        public static BonusObject BonusObjectHandler()
        {
            return null;
        }

        static void Test()
        {
            HandlerMethod handlerInteractableObject = InteractableObjectHandler;
            HandlerMethod handlerBonusObject = BonusObjectHandler;
            //Using of InteractableObject Child
        }
        #endregion
        //Contrvariance 
        #region Contrvariance


        public class InteractiveObjectArgs : EventArgs {}
        public class BonusArgs : EventArgs{}

        class InteractableObjectContr
        {
            public delegate void InteractiveObjectEventHandler(object sender, InteractiveObjectArgs e);
            public event InteractiveObjectEventHandler OnInteractiveObjectNotify;
        }

        class BonusObjectContr : InteractableObject
        {
            public delegate void BonusEventHandler(object sender, BonusArgs e);
            public event BonusEventHandler OnBonusNotify;
        }

        //Handler
        private void MultiHandler(object sender, EventArgs e)
        {
            if (e is InteractiveObjectArgs)
            {
                //Dostuff
            }
            else if (e is BonusArgs)
            {
                //Do other stuff
            }
        }

        void AttachHandler()
        {
            InteractableObjectContr intObj = new InteractableObjectContr();
            BonusObjectContr bonusObj = new BonusObjectContr();

            intObj.OnInteractiveObjectNotify += MultiHandler;
            bonusObj.OnBonusNotify += MultiHandler;
            //Using one handler to rule them all
        }
        #endregion
    }

}
