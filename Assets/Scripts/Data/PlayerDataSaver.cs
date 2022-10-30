using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollerBall.Data
{
    public class PlayerDataSaver : MonoBehaviour
    {
        [SerializeField] private InputField nameField;
        [SerializeField] private Text progressText;

        private void Start()
        {
            SetNameText();
            SetProgressText();

        }

        public void SetName()
        {
            string playerName = nameField.text;
            if (playerName != "")
            {
                PlayerPrefs.SetString("Name", playerName);
            }
        }
        private void SetNameText()
        {
            string playerName = PlayerPrefs.GetString("Name", "");
            if (playerName != "")
            {
                nameField.text = playerName;
            }
        }
        private void SetProgressText()
        {
            int progress = PlayerPrefs.GetInt("Progress", 0);
            progressText.text = $"Your progress: {progress.ToString()}";
        }
    }

}
