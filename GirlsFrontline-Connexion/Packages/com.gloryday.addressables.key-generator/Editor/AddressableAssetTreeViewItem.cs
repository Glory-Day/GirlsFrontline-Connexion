#if UNITY_EDITOR

using UnityEditor.IMGUI.Controls;

namespace GloryDay.Addressables
{
    public sealed class AddressableAssetTreeViewItem : TreeViewItem
    {
        private string _key;

        public AddressableAssetTreeViewItem(int id) : base(id)
        {
            depth = 0;
        }

        public string Path { get; set; }

        public string Key { get => _key; set => _key = ScriptGenerator.ToFieldName(value); }
    }
}

#endif
