using System.Collections.Generic;

namespace Core.UI.Controller.VideoPlayer
{
    public class LoopPointEventBinder
    {
        private UnityEngine.Video.VideoPlayer _videoPlayer;

        private List<UnityEngine.Video.VideoPlayer.EventHandler> _handlers = new List<UnityEngine.Video.VideoPlayer.EventHandler>();

        public LoopPointEventBinder(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
        }

        public void Add(UnityEngine.Video.VideoPlayer.EventHandler handler)
        {
            _videoPlayer.loopPointReached += handler;

            _handlers.Add(handler);
        }

        public void Remove(UnityEngine.Video.VideoPlayer.EventHandler handler)
        {
            _handlers.Remove(handler);

            _videoPlayer.loopPointReached -= handler;
        }

        public void Clear()
        {
            var count = _handlers.Count;
            for (var i = 0; i < count; i++)
            {
                _videoPlayer.loopPointReached -= _handlers[i];
            }

            _handlers.Clear();
        }
    }
}
