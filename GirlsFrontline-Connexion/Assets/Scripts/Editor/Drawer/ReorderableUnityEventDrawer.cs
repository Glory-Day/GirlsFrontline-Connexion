using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;
using Backend.Utility.Attribute;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/Editor/ReorderableUnityEventDrawer.cs
namespace Core.Utility.Extension.Editor
========
namespace Backend.Editor.Drawer
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Editor/Drawer/ReorderableUnityEventDrawer.cs
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
