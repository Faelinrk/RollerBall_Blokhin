using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RollerBall.Units;

namespace RollerBall.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text hpText;
        [SerializeField] TMP_Text speedText;
        private void Awake()
        {
            Player.OnHpChanged += ChangeHPText;
            Player.OnSpeedChanged += ChangeSpeedText;
        }
        private void ChangeHPText(float hp)
        {
            hpText.text = $"HP: {hp}";
        }
        private void ChangeSpeedText(float speed)
        {
            speedText.text = $"Speed: {speed}";
        }
    }

}
