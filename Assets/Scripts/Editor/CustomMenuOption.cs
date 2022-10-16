using UnityEditor;

namespace RollerBall.Editor
{
    public class CustomMenuOption
    {
        [MenuItem("RollerBall/EditorWindow")]
        private static void MenuItem()
        {
            EditorWindow.GetWindow(typeof(CustomWindow), false, "Data Window");
        }
    }
}
