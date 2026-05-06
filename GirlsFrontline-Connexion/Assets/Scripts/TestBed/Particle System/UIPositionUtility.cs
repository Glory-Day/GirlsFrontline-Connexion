using UnityEngine;

namespace DefaultNamespace
{
    public static class UIPositionUtility
    {
        public static Vector2 ToAnchoredPosition(RectTransform rect, Camera camera, Vector3 position, Camera uiCamera = null)
        {
            var screen = camera.WorldToScreenPoint(position);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screen, uiCamera, out var point);

            return point;
        }
    }
}
