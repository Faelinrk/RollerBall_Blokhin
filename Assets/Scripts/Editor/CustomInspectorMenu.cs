using UnityEditor;
using UnityEngine;
using RollerBall.Interactable;

namespace RollerBall.Editor
{
    [CustomEditor(typeof(BonusManager))]
    public class CustomInspectorBonusMenu : UnityEditor.Editor
    {
        BonusManager script;
        GameObject scriptObject;
        private void OnEnable()
        {
            script = (BonusManager)target;
            scriptObject = script.gameObject;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            bool isPressButton = GUILayout.Button("Create Bonuses From Data");
            if (isPressButton)
            {
                script.InstantiateFromLoad();
            }
        }
    }

    [CustomEditor(typeof(TrapManager))]
    public class CustomInspectorTrapMenu : UnityEditor.Editor
    {
        TrapManager script;
        GameObject scriptObject;
        private void OnEnable()
        {
            script = (TrapManager)target;
            scriptObject = script.gameObject;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            bool isPressButton = GUILayout.Button("Create Traps From Data");
            if (isPressButton)
            {
                script.InstantiateFromLoad();
            }
        }
    }

}

