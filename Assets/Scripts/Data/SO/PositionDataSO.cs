using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RollerBall.Data
{
    [CreateAssetMenu(fileName = "New XMLPositionDataObject", menuName = "Data", order = 51)]
    public class PositionDataSO : ScriptableObject
    {
        private XMLData<List<Vector3>> dataSerializator = new XMLData<List<Vector3>>();
        [field: SerializeField] public List<Vector3> Position { get; set; }

        public string SavePath { get; set; }
        public void InitializeSaver(string path, List<Vector3> position)
        {
            SavePath = path;
            Position = position;
        }
        public void SaveData()
        {
            string path = Path.Combine(Application.persistentDataPath, $"{SavePath}.xml");
            Debug.Log(path);
            dataSerializator.Save(Position, path);
        }
        public List<Vector3> LoadData(string dataPath)
        {
            SavePath = dataPath;
            string path = Path.Combine(Application.persistentDataPath, $"{SavePath}.xml");
            return dataSerializator.Load(path);
        }
    }

}

