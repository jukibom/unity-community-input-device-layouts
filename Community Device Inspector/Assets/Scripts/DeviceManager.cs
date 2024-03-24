using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CommunityDeviceInspector
{
    public class DeviceManager : MonoBehaviour
    {
        [SerializeField] private DeviceSelector _deviceSelector;
        [SerializeField] private DeviceControls _deviceControls;
        [SerializeField] private DeviceInspector _deviceInspector;

        [CanBeNull] private InputDevice _device;
        
        private void OnEnable()
        {
            _deviceSelector.OnDeviceSelected += OnDeviceSelected;
        }

        private void OnDisable()
        {
            _deviceSelector.OnDeviceSelected -= OnDeviceSelected;
        }

        private void OnDeviceSelected([CanBeNull] InputDevice device)
        {
            _device = device;
            _deviceControls.Clear();
            if (_device != null)
            {
                _deviceControls.Refresh(_device);
            }
        }

        private void FixedUpdate()
        {
            if (_device != null)
            {
                var state = DeviceRawStateQuery.StateForDevice(_device);
                _deviceInspector.DeviceData = state;
            }
        }
    }
}