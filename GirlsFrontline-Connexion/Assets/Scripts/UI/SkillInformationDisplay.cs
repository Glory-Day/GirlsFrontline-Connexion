using GloryDay.Animation;
using GloryDay.Debug.Log;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class SkillInformationDisplay : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [FormerlySerializedAs("backgroundImage01")]
        [Header("Textures")] 
        [SerializeField] private Texture enabledBackgroundImage;
        [FormerlySerializedAs("backgroundImage02")] [SerializeField] private Texture disabledBackgroundImage;
        
        [FormerlySerializedAs("color01")]
        [Header("Colors")]
        [SerializeField] private Color enabledColor;
        [FormerlySerializedAs("color02")] [SerializeField] private Color disabledColor;
        
        #endregion

        #region COMPONENT FIELD API

        private Animation _animation;
        
        private RawImage _backgroundImage;
        private RawImage _iconBackgroundImage;

        private Slider _progressSlider;
        private Image _progressSliderImage;

        private TMP_Text _coolDownTimeText;
        
        #endregion

        private AnimationNameList _animationNames;

        private void Awake()
        {
            LogManager.LogProgress();
            
            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);

            _progressSliderImage = transform.GetChild(5).GetComponentInChildren<Image>();
            _backgroundImage = transform.GetChild(0).GetComponent<RawImage>();
            _iconBackgroundImage = transform.GetChild(3).GetChild(0).GetComponent<RawImage>();

            _progressSlider = transform.GetChild(5).GetComponent<Slider>();
            
            _coolDownTimeText = transform.GetChild(3).GetChild(3).GetComponent<TMP_Text>();
        }

        public void DisplaySkillActivated()
        {
            LogManager.LogProgress();
            
            _backgroundImage.texture = enabledBackgroundImage;
            _progressSliderImage.color = enabledColor;
            _iconBackgroundImage.color = enabledColor;
        }

        public void DisplaySkillDeactivated()
        {
            LogManager.LogProgress();
            
            _backgroundImage.texture = disabledBackgroundImage;
            _progressSliderImage.color = disabledColor;
            _iconBackgroundImage.color = disabledColor;
        }

        public void PlayCooldownStarted()
        {
            LogManager.LogProgress();
            
            _animation.clip = _animation.GetClip(_animationNames[1]);
            _animation.Play();
        }

        public void PlayCooldownCompleted()
        {
            LogManager.LogProgress();
            
            _animation.clip = _animation.GetClip(_animationNames[0]);
            _animation.Play();
            
            _coolDownTimeText.text = string.Empty;
        }

        public void SetCooldownTime(float cooldownTime)
        {
            _coolDownTimeText.text = $"{cooldownTime:F1}";
        }

        public void SetProgress(float progress)
        {
            _progressSlider.value = progress;
        }
    }
}