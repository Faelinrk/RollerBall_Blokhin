using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RollerBall.UI
{
    public class UIButtons : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        private void Start()
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

