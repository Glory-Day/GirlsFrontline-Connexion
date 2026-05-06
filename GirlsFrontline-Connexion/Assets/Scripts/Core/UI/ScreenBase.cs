using System;
using GloryDay.Debug;
using UnityEngine;

using Console = GloryDay.Debug.Console;

namespace GloryDay.UI
{
    public class ScreenBase : MonoBehaviour, IComparable<ScreenBase>, IEquatable<ScreenBase>
    {
        #region COMPONENT FIELD API

        private Canvas _canvas;

        #endregion

        protected ScreenType Type = ScreenType.Default;

        protected virtual void Awake()
        {
            Console.LogProgress();

            if (TryGetComponent(out _canvas) == false)
            {
                _canvas = GetComponentInParent<Canvas>();
            }
        }

        /// <summary>
        /// Turn on the screen.
        /// </summary>
        public virtual void TurnOn()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Turn off the screen.
        /// </summary>
        public virtual void TurnOff()
        {
            gameObject.SetActive(false);
        }

        protected void SetRenderMode(RenderMode mode)
        {
            Console.LogProgress();
            
            _canvas.renderMode = mode;
            switch (mode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    break;
                case RenderMode.ScreenSpaceCamera:
                    _canvas.worldCamera = FindObjectOfType<Camera>();
                    break;
                case RenderMode.WorldSpace:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public int CompareTo(ScreenBase other)
        {
            var value = Type.CompareTo(other.Type);
            
            return value == 0 ? SortingOrder.CompareTo(other.SortingOrder) : value;
        }

        public bool Equals(ScreenBase other)
        {
            return other is null == false && Type == other.Type;
        }

        public override bool Equals(object other)
        {
            return other is ScreenBase screen && Equals(screen);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(ScreenBase a, ScreenBase b)
        {
            return a is null == false && a.Equals(b);
        }

        public static bool operator !=(ScreenBase a, ScreenBase b)
        {
            return a is null == false && a.Equals(b) == false;
        }

        protected int SortingOrder
        {
            get => _canvas.sortingOrder;
            set => _canvas.sortingOrder = value;
        }

        public string PrivateKey => $"{name}-{GetHashCode()}";
    }
}