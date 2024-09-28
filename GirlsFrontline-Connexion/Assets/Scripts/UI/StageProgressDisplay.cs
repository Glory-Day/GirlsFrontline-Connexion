using System.Collections;
using GloryDay.Animations;
using GloryDay.Log;
using UnityEngine;
using UnityEngine.UI;
using Utility.Manager;

namespace UI
{
    public class StageProgressDisplay : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API
        
        [Header("Stage Icon Color Transition")]
        [SerializeField] private Color enabledColor;
        [SerializeField] private Color disabledColor;

        #endregion

        #region COMPONENT FIELD API

        private readonly Slider[] _processSliders = new Slider[6];
        private readonly RawImage[] _stageIconImages = new RawImage[7];
        private RawImage _bossStageIconImage;
        
        private readonly Animation[] _animations = new Animation[7];

        #endregion

        #region CONSTANT FIELD API

        private const float Duration = 10f;

        #endregion

        private AnimationNameList _animationNames;
        
        private readonly GameObject[] _currentStageDisplayImageObjects = new GameObject[7];
        private readonly GameObject[] _nextStageDisplayImageObjects = new GameObject[7];

        private int _index;

        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            _index = 0;
            
            // Initialize slider component to display progress.
            for (var i = 0; i < 6; i++)
            {
                _processSliders[i] = transform.GetChild(i + 1).GetComponent<Slider>();
            }

            // Initialize components in stage icon container.
            for (var i = 0; i < 7; i++)
            {
                var child = transform.GetChild(i + 7);
                _animations[i] = child.GetComponent<Animation>();
                _stageIconImages[i] = child.GetChild(0).GetComponent<RawImage>();
                
                // Initialize instance to display current and next stage.
                _currentStageDisplayImageObjects[i] = child.GetChild(1).gameObject;
                _nextStageDisplayImageObjects[i] = child.GetChild(2).gameObject;
            }

            _bossStageIconImage = transform.GetChild(13).GetChild(3).GetComponent<RawImage>();
            
            _animationNames = new AnimationNameList(_animations[0]);
        }

        /// <summary>
        /// Display progression to the next stage.
        /// </summary>
        public void DisplayProgressToNextStage()
        {
            LogManager.LogProgress();
            
            StartCoroutine(DisplayingProgressToNextStage());
        }
        
        private IEnumerator DisplayingProgressToNextStage()
        {
            IsDisplaying = true;
            
            // Activate current and next stage display image object.
            _currentStageDisplayImageObjects[_index].SetActive(true);
            _nextStageDisplayImageObjects[_index + 1].SetActive(true);
            
            // Play the animation that display the current and next stage.
            _animations[_index].Play(_animationNames[0]);
            _animations[_index + 1].Play(_animationNames[1]);
            
            var deltaTime = Time.deltaTime;
            for (var i = 0f; i < Duration; i += deltaTime)
            {
                var progress = i / Duration;
                _processSliders[_index].value = progress;

                yield return _instruction;
            }
            
            IsDisplaying = false;
        }

        /// <summary>
        /// Display that the progression of the stage is complete.
        /// </summary>
        public void DisplayStageCompleted()
        {
            // Stop the animation that display the current and next stage.
            _animations[_index].Stop(_animationNames[0]);
            _animations[_index + 1].Stop(_animationNames[1]);
            
            // Deactivate current and next stage display image object.
            _currentStageDisplayImageObjects[_index].SetActive(false);
            _nextStageDisplayImageObjects[_index + 1].SetActive(false);
            
            _stageIconImages[_index].color = enabledColor;
            _processSliders[_index].value = 1f;

            _index++;
        }
        
        public bool IsDisplaying { get; private set; }
    }
}