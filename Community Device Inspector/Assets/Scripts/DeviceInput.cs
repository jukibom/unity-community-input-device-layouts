using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceInput : MonoBehaviour
{
    [SerializeField] private TMP_Text _inputControlName;
    public void SetControls(InputControl inputControl)
    {
        _inputControlName.text = $"{inputControl.name} {inputControl.valueType.Name}";
    }
}