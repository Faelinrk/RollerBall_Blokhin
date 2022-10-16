using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using RollerBall.Interactable;
using RollerBall.Data;

namespace RollerBall.Editor
{
    public class CustomWindow : EditorWindow
    {
        public static BonusManager BonusMan;
        public static TrapManager TrapMan;
        public static PositionDataSO DataWorker;
        private List<Vector3> bonusPositions;
        private List<Vector3> trapsPositions;


        private void OnGUI()
        {
            GUILayout.Label("Generate map from data");
            BonusMan = EditorGUILayout.ObjectField("Bonus Manager", BonusMan, typeof(BonusManager), true) as BonusManager;
            TrapMan = EditorGUILayout.ObjectField("Trap Manager", TrapMan, typeof(TrapManager), true) as TrapManager;
            var buttonCreate = GUILayout.Button("Create Objects From Data");
            if (buttonCreate)
            {
                BonusMan.InstantiateFromLoad();
                TrapMan.InstantiateFromLoad();
            }
        }
    }

}
