using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CommunityDeviceInspector
{
    public class DeviceSelector : MonoBehaviour
    {
        private const string placeholderText = "Select Device ...";
        private const string emptyDeviceText = "None";
        public delegate void DeviceSelected([CanBeNull] InputDevice device);
        public event DeviceSelected OnDeviceSelected;

        [SerializeField] private TMP_Dropdown _dropdown;

        [CanBeNull] private InputDevice _currentDevice;

        private bool _deviceHasBeenSelected;
        
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
            _currentDevice = index > 0 ? InputSystem.devices[index - 1] : null;
            OnDeviceSelected?.Invoke(_currentDevice);
            
            // dropdown UI tidying stuff
            if (!_deviceHasBeenSelected)
            {
                _deviceHasBeenSelected = true;
                _dropdown.options[0].text = emptyDeviceText;
            }
        }

        private void DetectDevices()
        {
            var currentName = _currentDevice?.name ?? "";
            _dropdown.ClearOptions();

            var options = InputSystem.devices.Select(device => new TMP_Dropdown.OptionData(device.name)).ToList();
            
            // prepend an empty placeholder field for UX - "Select Device ..." at first, then "None" after any device is selected.
            options = options.Prepend(new TMP_Dropdown.OptionData(_deviceHasBeenSelected ? emptyDeviceText : placeholderText)).ToList();
            
            _dropdown.AddOptions(options);

            if (!string.IsNullOrEmpty(currentName))
            {
                int deviceIndex = InputSystem.devices.IndexOf(device => device.name.Equals(currentName));
                _dropdown.value = deviceIndex + 1;
            }
        }

        private void Update()
        {
            if (_currentDevice != null)
            {
                var state = DeviceRawStateQuery.StateForDevice(_currentDevice, Endian.Little);
                Debug.Log(state.binaryString);
            }
        }
    }
}