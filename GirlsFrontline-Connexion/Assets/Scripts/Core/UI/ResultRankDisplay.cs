using GloryDay.Animation;
using GloryDay.Debug;
using UnityEngine;
using UnityEngine.UI;
using Core.Utility.Attribute;
using Core.Utility.Management;
using Core.Utility.Management.Resource;

namespace Core.UI
{
    [RequireComponent(typeof(Animation))]
    public class ResultRankDisplay : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private RawImage rankImage;
        [SerializeField] private RawImage backgroundImage;

        [Header("S Rank")]
        [Alias("Texture")]
        [SerializeField] private Texture sRankTexture;

        [Alias("Background Color")]
        [SerializeField] private Color sRankBackgroundColor;

        [Header("A Rank")]
        [Alias("Texture")]
        [SerializeField] private Texture aRankTexture;

        [Alias("Background Color")]
        [SerializeField] private Color aRankBackgroundColor;

        [Header("B Rank")]
        [Alias("Texture")]
        [SerializeField] private Texture bRankTexture;

        [Alias("Background Color")]
        [SerializeField] private Color bRankBackgroundColor;

        [Header("C Rank")]
        [Alias("Texture")]
        [SerializeField] private Texture cRankTexture;

        [Alias("Background Color")]
        [SerializeField] private Color cRankBackgroundColor;

        [Header("D Rank")]
        [Alias("Texture")]
        [SerializeField] private Texture dRankTexture;

        [Alias("Background Color")]
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
            Console.LogProgress();

            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);
            
            _displayRankSound = AssetManager.Asset.Audio.UI[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Display_Rank_Wav];
        }

        public void SetRank(int score)
        {
            Console.LogProgress();

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
            Console.LogProgress();

            if (gameObject.activeSelf)
            {
                SoundManager.PlayEffectAudioSource(_displayRankSound);
            }
            
            _animation[_animationNames[0]].speed = 1f;
            _animation.Play(_animationNames[0]);
        }

        public void Rewind()
        {
            Console.LogProgress();
            
            _animation[_animationNames[0]].speed = -1f;
            _animation.Play(_animationNames[0]);
        }
        
        public bool IsPlaying => _animation.isPlaying;
    }
}
