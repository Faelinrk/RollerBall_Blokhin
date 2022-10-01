using RollerBall.Interactable;
using TMPro;
using UnityEngine;

namespace RollerBall.UI
{
    public class BonusUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text bonusCountText;
        private void Awake()
        {
            BonusManager.OnBonusCountChanged += ChangeBonusText;
        }
        private void ChangeBonusText(int count)
        {
            bonusCountText.text = $"Bonus Left: {count}";
        }
    }

}
