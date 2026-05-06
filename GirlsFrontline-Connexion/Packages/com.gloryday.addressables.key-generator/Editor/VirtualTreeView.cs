#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace GloryDay.Addressables
{
    public class VirtualTreeView : TreeView
    {
        #region CONSTANT FIELD API

        private const string PathHeaderText = "Address/Path";
        private const string KeyHeaderText = "Key";

        private const float IconColumnWidth = 24f;
        private const float MinimizePathColumnWidth = 120f;
        private const float MinimizeKeyColumnWidth = 120f;
        private const float PathColumnWeight = 0.45f;
        private const float KeyColumnWeight = 0.55f;

        #endregion

        private readonly List<TreeViewItem> _items = new List<TreeViewItem>();

        private float _lastWidth = -1f;

        private VirtualTreeView(TreeViewState state, MultiColumnHeader header) : base(state, header)
        {
            showAlternatingRowBackgrounds = true;
            showBorder = true;
        }

        protected override TreeViewItem BuildRoot()
        {
            return new TreeViewItem { id = 0, depth = -1 };
        }

        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            return _items;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = args.item as AddressableAssetTreeViewItem;
            if (item == null)
            {
                return;
            }

            var count = args.GetNumVisibleColumns();
            for (var i = 0; i < count; i++)
            {
                var bound = args.GetCellRect(i);
                var index = args.GetColumn(i);
                switch (index)
                {
                    case 1:
                        EditorGUI.LabelField(bound, item.Path);
                        break;
                    case 2:
                        EditorGUI.LabelField(bound, item.Key);
                        break;
                }
            }
        }

        public void Draw(Rect rect)
        {
            AdjustColumnWidths(rect.width);

            OnGUI(rect);
        }

        private void AdjustColumnWidths(float width)
        {
            if (Mathf.Approximately(width, _lastWidth))
            {
                return;
            }

            _lastWidth = width;

            var columns = multiColumnHeader.state.columns;
            columns[0].width = IconColumnWidth;

            var scrollbarWidth = GUI.skin.verticalScrollbar.fixedWidth;
            var available = width - IconColumnWidth - scrollbarWidth;

            var sum = MinimizePathColumnWidth + MinimizeKeyColumnWidth;
            if (available < sum)
            {
                available = sum;
            }

            var pathWidth = Mathf.Max(MinimizePathColumnWidth, available * PathColumnWeight);
            var keyWidth = Mathf.Max(MinimizeKeyColumnWidth, available * KeyColumnWeight);

            sum = pathWidth + keyWidth;
            if (sum > available)
            {
                var overflowed = sum - available;

                var reducible = pathWidth - MinimizePathColumnWidth;
                var reduced = Mathf.Min(overflowed, reducible);
                pathWidth -= reduced;
                overflowed -= reduced;

                if (overflowed > 0f)
                {
                    reducible = keyWidth - MinimizeKeyColumnWidth;
                    reduced = Mathf.Min(reduced, overflowed);
                    keyWidth -= reduced;
                }
            }

            columns[1].width = pathWidth;
            columns[2].width = keyWidth;
        }

        public static VirtualTreeView Build()
        {
            var columns = new MultiColumnHeaderState.Column[3];
            columns[0] = new MultiColumnHeaderState.Column
            {
                allowToggleVisibility = true,
                autoResize = false,
                canSort = false,
                headerContent = new GUIContent(EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow")),
                headerTextAlignment = TextAlignment.Center,
                width = IconColumnWidth,
                minWidth = IconColumnWidth,
                maxWidth = IconColumnWidth
            };
            columns[1] = new MultiColumnHeaderState.Column
            {
                allowToggleVisibility = true,
                autoResize = false,
                canSort = true,
                sortingArrowAlignment = TextAlignment.Right,
                headerContent = new GUIContent(PathHeaderText),
                headerTextAlignment = TextAlignment.Left,
                width = 200f,
                minWidth = MinimizePathColumnWidth
            };
            columns[2] = new MultiColumnHeaderState.Column
            {
                allowToggleVisibility = true,
                autoResize = false,
                canSort = false,
                sortingArrowAlignment = TextAlignment.Center,
                headerContent = new GUIContent(KeyHeaderText),
                headerTextAlignment = TextAlignment.Left,
                width = 200f,
                minWidth = MinimizeKeyColumnWidth
            };

            var state = new TreeViewState();
            var header = new MultiColumnHeader(new MultiColumnHeaderState(columns));

            return new VirtualTreeView(state, header);
        }

        public void Update(AddressableAssetMetadata metadata)
        {
            var current = _items.Count;
            var updated = metadata.Addresses.Count;

            var count = Math.Min(current, updated);
            for (var i = 0; i < count; i++)
            {
                var address = metadata.Addresses[i];
                ((AddressableAssetTreeViewItem)_items[i]).Path = address;
                ((AddressableAssetTreeViewItem)_items[i]).Key = address;
            }

            if (updated > current)
            {
                for (var i = current; i < updated; i++)
                {
                    var address = metadata.Addresses[i];
                    var item = new AddressableAssetTreeViewItem(i) { Path = address, Key = address };

                    _items.Add(item);
                }
            }
            else if (updated < current)
            {
                _items.RemoveRange(updated, current - updated);
            }

            Reload();
        }
    }
}

#endif
