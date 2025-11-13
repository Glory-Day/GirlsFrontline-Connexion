using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;
using Backend.Utility.Attribute;

namespace Backend.Editor.Drawer
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
