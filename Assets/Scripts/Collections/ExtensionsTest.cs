using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollerBall.Extensions;


namespace RollerBall
{
    public class ExtensionsTest : MonoBehaviour
    {
        [SerializeField] private string str = "string";
        void Start()
        {
            print($"String len: {str.StringLen()}");
        }
    }

}
