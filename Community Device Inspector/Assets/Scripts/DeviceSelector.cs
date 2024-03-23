using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceSelector : MonoBehaviour
{
    public delegate void DeviceSelected(InputDevice device);
    public event DeviceSelected OnDeviceSelected;
    
    [SerializeField] private TMP_Dropdown _dropdown;
    
    [CanBeNull] private InputDevice _currentDevice;
    
    private void Start()
    {
        DetectDevices();
    }

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnConnectedDevicesChange;
        _dropdown.onValueChanged.AddListener(OnDropdownDeviceSelected);
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnConnectedDevicesChange;
        _dropdown.onValueChanged.RemoveListener(OnDropdownDeviceSelected);
    }

    private void OnConnectedDevicesChange(InputDevice _, InputDeviceChange change)
    {
        if (change is not (InputDeviceChange.Added or InputDeviceChange.Removed)) return;
        
        DetectDevices();
    }

    private void OnDropdownDeviceSelected(int index)
    {
        _currentDevice = InputSystem.devices[index];
        OnDeviceSelected?.Invoke(_currentDevice);
    }

    void DetectDevices()
    {
        var currentName = _currentDevice?.name ?? "";
        _dropdown.ClearOptions();
        _dropdown.AddOptions(InputSystem.devices.Select(device => new TMP_Dropdown.OptionData(device.name)).ToList());
        
        if (!string.IsNullOrEmpty(currentName))
        {
            int currentIndex = InputSystem.devices.IndexOf(device => device.name.Equals(currentName));
            _dropdown.value = currentIndex;
        }
    }
}
