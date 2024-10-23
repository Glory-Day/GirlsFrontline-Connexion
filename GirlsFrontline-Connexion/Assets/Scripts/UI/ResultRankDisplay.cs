using GloryDay.Animation;
using GloryDay.Debug.Log;
using UnityEngine;
using UnityEngine.UI;
using Utility.Extension;
using Utility.Manager;

namespace UI
{
    [RequireComponent(typeof(Animation))]
    public class ResultRankDisplay : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private RawImage rankImage;
        [SerializeField] private RawImage backgroundImage;
        
        [Header("S Rank")]
        [Label("Texture")]
        [SerializeField] private Texture sRankTexture;
        [Label("Background Color")]
        [SerializeField] private Color sRankBackgroundColor;
        
        [Header("A Rank")]
        [Label("Texture")]
        [SerializeField] private Texture aRankTexture;
        [Label("Background Color")]
        [SerializeField] private Color aRankBackgroundColor;
        
        [Header("B Rank")]
        [Label("Texture")]
        [SerializeField] private Texture bRankTexture;
        [Label("Background Color")]
        [SerializeField] private Color bRankBackgroundColor;
        
        [Header("C Rank")]
        [Label("Texture")]
        [SerializeField] private Texture cRankTexture;
        [Label("Background Color")]
        [SerializeField] private Color cRankBackgroundColor;
        
        [Header("D Rank")]
        [Label("Texture")]
        [SerializeField] private Texture dRankTexture;
        [Label("Background Color")]
        [SerializeField] private Color dRankBackgroundColor;

        #endregion

        #region COMPONENT FIELD API

        private Animation _animation;

        #endregion
        
        #region CONSTANT FIELD API

        private const int MinimumSRankPoint = 100000;
        private const int MinimumARankPoint = 70000;
        private const int MinimumBRankPoint = 50000;
        private const int MinimumCRankPoint = 30000;

        #endregion

        private AnimationNameList _animationNames;
        
        private AudioClip _displayRankSound;

        private void Awake()
        {
            LogManager.LogProgress();

            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);
            
            var key = DataManager.AudioData.Effect[8];
            _displayRankSound = ResourceManager.AudioClipResource.Effect[key];
        }

        public void SetRank(int score)
        {
            LogManager.LogProgress();

            Texture texture = null;
            Color? color = null;
            switch (score)
            {
                case var _ when score > MinimumSRankPoint:
                    texture = sRankTexture;
                    color = sRankBackgroundColor;
                    break;
                case var _ when MinimumARankPoint <= score && score < MinimumSRankPoint: 
                    texture = aRankTexture;
                    color = aRankBackgroundColor;
                    break;
                case var _ when MinimumBRankPoint <= score && score < MinimumARankPoint: 
                    texture = bRankTexture;
                    color = bRankBackgroundColor;
                    break;
                case var _ when MinimumCRankPoint <= score && score < MinimumBRankPoint: 
                    texture = cRankTexture;
                    color = cRankBackgroundColor;
                    break;
                default: 
                    texture = dRankTexture;
                    color = dRankBackgroundColor;
                    break;
            }
            
            rankImage.texture = texture;
            if (backgroundImage is null == false)
            {
                backgroundImage.color = color.Value;
            }
        }

        public void Play()
        {
            LogManager.LogProgress();

            if (gameObject.activeSelf)
            {
                SoundManager.OnPlayEffectAudioSource(_displayRankSound);
            }
            
            _animation[_animationNames[0]].speed = 1f;
            _animation.Play(_animationNames[0]);
        }

        public void Rewind()
        {
            LogManager.LogProgress();
            
            _animation[_animationNames[0]].speed = -1f;
            _animation.Play(_animationNames[0]);
        }
        
        public bool IsPlaying => _animation.isPlaying;
    }
}