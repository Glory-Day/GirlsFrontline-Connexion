using System.Collections;
using UnityEngine;
using Utility;

namespace Object.Map
{
    public abstract class TileState : IDisplayable
    {
        protected readonly SpriteRenderer Renderer;
        protected readonly float FixedDeltaTime;
        
        protected IEnumerator Coroutine;
        
        protected int Count;

        protected TileState(SpriteRenderer renderer)
        {
            Renderer = renderer;
            Renderer.color = new Color(1f, 1f, 1f, 0f);

            Coroutine = null;

            FixedDeltaTime = Time.fixedDeltaTime;
            Count = 0;
        }
        
        public abstract void StartDisplaying();

        public abstract void StopDisplaying();

        public bool IsDisplaying => Count != 0;
    }
}