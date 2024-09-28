using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;

namespace Utility.Extension.Editor
{
    [CustomPropertyDrawer(typeof(UnityEventBase), true)]
    public class ReorderableUnityEventDrawer : UnityEventDrawer
    {
        protected override void SetupReorderableList(ReorderableList list)
        {
            base.SetupReorderableList(list);

            list.draggable = true;
        }
    }
}