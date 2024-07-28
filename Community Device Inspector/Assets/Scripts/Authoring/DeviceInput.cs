using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CommunityDeviceInspector
{
    public class DeviceInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputControlName;
        [SerializeField] private Transform _childContainer;

        public List<DeviceInput> Children { get; private set; } = new();
        private DeviceInput _prefab;

        public void Initialize(DeviceInput prefab)
        {
            _prefab = prefab;
        }
        
        public void SetControls(InputControl inputControl)
        {
            _inputControlName.text =
                $"{inputControl.name}"; // {inputControl.valueType.Name} {inputControl.GetType()} {inputControl.stateBlock.format} {inputControl.stateBlock.bitOffset} {inputControl.stateBlock.byteOffset} {inputControl.stateBlock.sizeInBits} {inputControl.layout}";

            // recurse over children 
            foreach (var deviceControlChild in inputControl.children)
            {
                AddChild(deviceControlChild);
            }
        }

        public void AddChild(InputControl inputControl = null)
        {
            if (_prefab == null)
            {
                Debug.LogError("Cannot add child, initialize has not been called.");
                return;
            }
            
            var deviceInputChild = Instantiate(_prefab, _childContainer);
            Children.Add(deviceInputChild);
            
            deviceInputChild.Initialize(_prefab);
            if (inputControl != null) deviceInputChild.SetControls(inputControl);
        }
    }
}