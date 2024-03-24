using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CommunityDeviceInspector
{
    public class DeviceInput : MonoBehaviour
    {
        [SerializeField] private TMP_Text _inputControlName;

        public void SetControls(InputControl inputControl)
        {
            _inputControlName.text =
                $"{inputControl.name} {inputControl.valueType.Name} {inputControl.GetType()} {inputControl.stateBlock.format} {inputControl.stateBlock.bitOffset} {inputControl.stateBlock.byteOffset} {inputControl.stateBlock.sizeInBits} {inputControl.layout}";
        }
    }
}