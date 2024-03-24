using UnityEngine;
using UnityEngine.InputSystem;

namespace CommunityDeviceInspector
{
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
        private void OnDeviceSelected([CanBeNull] InputDevice device)
        {
            _deviceControls.Clear();
            if (device != null)
            {
                _deviceControls.Refresh(device);
            }
        }
    }
}