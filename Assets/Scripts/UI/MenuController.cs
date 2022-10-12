using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void CloseMenuPanel()
    {
        panel.SetActive(false);
    }
    public void OpenMenuPanel()
    {
        panel.SetActive(true);
    }
}
