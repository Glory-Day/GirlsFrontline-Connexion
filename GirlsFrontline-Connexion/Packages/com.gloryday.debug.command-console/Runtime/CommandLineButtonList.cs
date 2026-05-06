using System;
using System.Collections.Generic;
using System.Linq;
using GloryDay.Debug;
using UnityEngine;

namespace GloryDay.Debug
{
    public class CommandLineButtonList
    {
        private readonly Transform _transform;
        private readonly Dictionary<string, GameObject> _buttons = new Dictionary<string, GameObject>();
        
        /// <param name="transform">  </param>
        public CommandLineButtonList(Transform transform)
        {
            Console.LogProgress();

            _transform = transform;
        }

        /// <summary>
        /// Instantiate built command line buttons
        /// </summary>
        /// <param name="callback"> Callback to input a command line in the input field </param>
        public void Instantiate(GameObject original, Action<string> callback)
        {
            Console.LogProgress();
            
            var count = CommandList.Count;
            for (var i = 0; i < count; i++)
            {
                var instance  = UnityEngine.Object.Instantiate(original, _transform);
                var component = instance.GetComponent<CommandLineButton>();
                var name = CommandList.Names[i];
                component.Text = name;
                component.AddListener(callback);
                instance.SetActive(false);
                
                _buttons.Add(name, instance);
            }
        }

        /// <returns>
        /// Number of instantiated command line buttons
        /// </returns>
        public int Count => _buttons.Count;

        /// <returns>
        /// 
        /// </returns>
        public string[] Keys => _buttons.Keys.ToArray();

        public GameObject this[string index] => _buttons[index];
    }
}