using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceControls : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private DeviceInput _deviceInputLinePrefab;
    
    public void Refresh(InputDevice device)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }

        foreach (var deviceControl in device.allControls)
        {
            var deviceInput = Instantiate(_deviceInputLinePrefab, _container);
            deviceInput.SetControls(deviceControl);
        }
    }
}
