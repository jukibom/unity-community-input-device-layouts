using System;
using CommunityDeviceInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Expander : MonoBehaviour
{
    [SerializeField] private DeviceInput _deviceInput;
    [SerializeField] private Transform _childrenContainer;
    [SerializeField] private Image _chevron;
    [SerializeField] private TMP_Text _plus;

    private void Awake()
    {
        _childrenContainer.gameObject.SetActive(false);
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        _chevron.gameObject.SetActive(false);
        _plus.gameObject.SetActive(false);
        
        // chevron
        if (_deviceInput.Children.Count > 0)
        {
            _chevron.gameObject.SetActive(true);
            var isActive = _childrenContainer.gameObject.activeSelf;
            _chevron.transform.localRotation = Quaternion.Euler(0, 0, isActive ? 0 : 90);
        }
        
        // plus button
        else
        {
            _plus.gameObject.SetActive(true);
        }
    }
    
    public void OnButtonClick()
    {
        if (_deviceInput.Children.Count == 0) _deviceInput.AddChild();
        _childrenContainer.gameObject.SetActive(!_childrenContainer.gameObject.activeSelf);
        Refresh();
    }
}
