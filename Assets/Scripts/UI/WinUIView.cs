using RollerBall.Interactable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.UI
{
    public class WinUIView : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        private void Awake()
        {
            BonusManager.OnBonusCountChanged += CheckWin;
        }
        private void CheckWin(int bonusCout)
        {
            if (bonusCout <= 0)
            {
                panel.SetActive(true);
            }
        }
    }
}

