using RollerBall.Units;
using TMPro;
using UnityEngine;

namespace RollerBall.UI
{
    public class PlayerUIView : MonoBehaviour
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
