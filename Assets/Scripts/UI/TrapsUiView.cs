using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollerBall.Interactable;
using TMPro;

namespace RollerBall.Ui
{
    public class TrapsUiView : MonoBehaviour
    {
        [SerializeField] private TMP_Text trapCountText;
        private void Awake()
        {
            TrapManager.OnTrapsCountChanged += ChangeTrapsText;
        }
        private void ChangeTrapsText(int count)
        {
            trapCountText.text = $"Traps count: {count}";
        }
    }
}

