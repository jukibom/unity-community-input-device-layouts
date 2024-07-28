using UnityEngine;
using UnityEngine.InputSystem;

namespace CommunityDeviceInspector
{
    public class DeviceControls : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private DeviceInput _deviceInputLinePrefab;

        public void Refresh(InputDevice device)
        {
            foreach (var deviceControl in device.children)
            {
                var deviceInput = Instantiate(_deviceInputLinePrefab, _container);
                deviceInput.Initialize(_deviceInputLinePrefab);
                deviceInput.SetControls(deviceControl);
            }
        }

        public void Clear()
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}