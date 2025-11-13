using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GloryDay.UI.InputSystem
{
    public class UIControls : IInputActionCollection, IDisposable
    {
        private const string DirectoryName = @"Packages\com.gloryday.uimodule@1.0.0\Runtime\InputSystem";
        private const string FileName = "UI Controls.inputactions";
        
        private int _windowPlatformSchemeIndex = -1;
        
        public UIControls()
        {
            string json;
            using (var reader = new StreamReader(Path.Combine(DirectoryName, FileName)))
            {
                json = reader.ReadToEnd();
            }
            
            Asset = InputActionAsset.FromJson(json);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(Asset);
        }

        public bool Contains(InputAction action)
        {
            return Asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return Asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            Asset.Enable();
        }

        public void Disable()
        {
            Asset.Disable();
        }
        
        public InputBinding? bindingMask
        {
            get => Asset.bindingMask;
            set => Asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => Asset.devices;
            set => Asset.devices = value;
        }
        
        public ReadOnlyArray<InputControlScheme> controlSchemes => Asset.controlSchemes;
        
        public InputActionAsset Asset { get; }
        

        public InputControlScheme WindowPlatformScheme
        {
            get
            {
                if (_windowPlatformSchemeIndex == -1)
                {
                    _windowPlatformSchemeIndex = Asset.FindControlSchemeIndex("Window Platform");
                }
                return Asset.controlSchemes[_windowPlatformSchemeIndex];
            }
        }
    }
}
