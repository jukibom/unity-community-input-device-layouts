using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceInspector : MonoBehaviour
{
    [SerializeField] private DeviceSelector _deviceSelector;
    [SerializeField] private DeviceControls _deviceControls;

    private void OnEnable()
    {
        _deviceSelector.OnDeviceSelected += OnDeviceSelected;
    }
    
    private void OnDisable()
    {
        _deviceSelector.OnDeviceSelected -= OnDeviceSelected;
    }

    private void OnDeviceSelected(InputDevice device)
    {
        _deviceControls.Refresh(device);
    }
}
