using System.Collections;
using GloryDay.Log;
using UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

namespace UI
{
    public class InformationDisplayHandler : MonoBehaviour
    {
        private readonly IDisplayable[] _displays = new IDisplayable[3];
        private IDisplayable _current;
        private IDisplayable _next;
        
        private MainInterfaceControls.InformationDisplayActions _actions;

        private StageProgressDisplay _stageProgressDisplay;
        
        private void Awake()
        {
            LogManager.LogProgress();

            _displays[0] = transform.GetChild(0).GetComponent<InformationDisplay>();
            _displays[1] = transform.GetChild(1).GetComponent<InformationDisplay>();
            
            // Initialize the stage progress display.
            var child = transform.GetChild(2);
            _displays[2] = child.GetComponent<InformationDisplay>();
            _stageProgressDisplay = child.GetChild(2).GetComponent<StageProgressDisplay>();
            
            // Initialize input system of information display.
            _actions = new MainInterfaceControls().InformationDisplay;
            _actions.DisplaySkillInformation.performed += DisplaySkillState;
            _actions.DisplayCharacterStatPointInformation.performed += DisplayCharacterStatPoints;
        }
        
        /// <summary>
        /// Display the player character's skill state.
        /// </summary>
        private void DisplaySkillState(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            if (_current == _displays[0])
            {
                return;
            }
            
            _next = _displays[0];
            StartCoroutine(Displaying());
        }
        
        /// <summary>
        /// Display the player character's stat points.
        /// </summary>
        private void DisplayCharacterStatPoints(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            if (_current == _displays[1])
            {
                return;
            }
            
            _next = _displays[1];
            StartCoroutine(Displaying());
        }

        /// <summary>
        /// Display the progress of the chapter's stages.
        /// </summary>
        public void DisplayStageProgress()
        {
            LogManager.LogProgress();

            StartCoroutine(DisplayingStageProgress());
        }
        
        private IEnumerator DisplayingStageProgress()
        {
            IsDisplayingStageProgress = true;

            _actions.Disable();
            
            // Turning off and save the information currently being displayed.
            var cache = _displays[0];
            if (_current is null == false)
            {
                cache = _current;
                _current.StopDisplaying();
                while (_current.IsDisplaying)
                {
                    yield return null;
                }
            }
            
            _next = _displays[2];
            _next.StartDisplaying();
            while (_next.IsDisplaying == false)
            {
                yield return null;
            }
            
            _current = _next;
            
            // Start Displaying information about progressing to the next stage.
            _stageProgressDisplay.DisplayProgressToNextStage();
            while (_stageProgressDisplay.IsDisplaying)
            {
                yield return null;
            }
            
            _stageProgressDisplay.DisplayStageCompleted();

            // Display the previously saved information.
            _next = cache;
            _current.StopDisplaying();
            while (_current.IsDisplaying)
            {
                yield return null;
            }
            
            _next.StartDisplaying();
            while (_next.IsDisplaying == false)
            {
                yield return null;
            }

            _actions.Enable();
            _current = _next;

            IsDisplayingStageProgress = false;
        }

        private IEnumerator Displaying()
        {
            yield return StartCoroutine(TurningOff());
            yield return StartCoroutine(TurningOn());
        }

        private IEnumerator TurningOff()
        {
            _actions.Disable();

            if (_current is null)
            {
                yield break;
            }
            
            _current.StopDisplaying();
            while (_current.IsDisplaying)
            {
                yield return null;
            }
        }

        private IEnumerator TurningOn()
        {
            _next.StartDisplaying();
            while (_next.IsDisplaying == false)
            {
                yield return null;
            }

            _actions.Enable();
            _current = _next;
        }
        
        public bool IsDisplayingStageProgress { get; private set; }
    }
}