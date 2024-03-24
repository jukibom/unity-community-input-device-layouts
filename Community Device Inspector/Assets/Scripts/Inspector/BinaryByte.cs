using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace CommunityDeviceInspector
{
    public class BinaryByte : MonoBehaviour
    {
        [SerializeField] private List<Digit> _binaryDigits;
        [SerializeField] private TMP_Text _offsetLabel;

        private byte _value;
        
        public byte Value
        {
            get => _value;
            set 
            {
                _value = value;
                RefreshDigits();
            }
        }
        
        public int Offset
        {
            get => int.Parse(_offsetLabel.text);
            set => _offsetLabel.text = value.ToString(CultureInfo.InvariantCulture);
        }

        private void RefreshDigits()
        {
            // break byte into binary values
            for (int i = 0; i < _binaryDigits.Count; i++)
            {
                _binaryDigits[i].Value = ((_value >> i) & 1).ToString();
            }
        }
    }

}