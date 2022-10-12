using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollerBall.UI
{
    public class RadarObj : MonoBehaviour
    {
        [SerializeField] private Image ico;

        public GameObject Owner { get; set; }
        public Image Img { get; set; }

        private void OnEnable()
        {
            Minimap.RegisterRadarObject(gameObject, ico);
        }
        private void OnDisable()
        {
            Minimap.RemoveRadarObject(gameObject);
        }
    }

}
