using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollerBall.UI
{
    public class Minimap : MonoBehaviour
    {
        private Transform playerPos;
        private float mapScale = 2f;
        public static List<RadarObj> ObjList = new List<RadarObj>();

   
        void Start()
        {
            playerPos = Camera.main.transform;
        }

        public static void RegisterRadarObject(GameObject obj, Image icon)
        {
            Image i = Instantiate(icon);
            ObjList.Add(new RadarObj{ Owner = obj, Img = i });
        }
        public static void RemoveRadarObject(GameObject obj)
        {
            List<RadarObj> newList = new List<RadarObj>();
            foreach(var radarObj in ObjList)
            {
                if (radarObj.Owner == obj)
                {
                    Destroy(radarObj.Img);
                    continue;
                }
                newList.Add(radarObj);
            }
            ObjList.Clear();
            ObjList.AddRange(newList);
        }

        private void DrawRadarDots()
        {
            foreach(var radObject in ObjList)
            {
                Vector3 radPos = (radObject.Owner.transform.position - playerPos.position) * mapScale;
                radObject.Img.transform.SetParent(transform);
                radObject.Img.transform.position = new Vector3(radPos.x, radPos.z, 0) + transform.position;
            }
        }

        private void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }

}
