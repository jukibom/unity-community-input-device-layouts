using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace CommunityDeviceInspector
{
    public class Byte : MonoBehaviour
    {

        [SerializeField] protected List<Digit> _digits;
        [SerializeField] protected TMP_Text _offsetLabel;

        protected byte _byteData;

        public byte Value
        {
            get => _byteData;
            set
            {
                _byteData = value;
                RefreshDigits();
            }
        }

        public int Offset
        {
            get => int.Parse(_offsetLabel.text);
            set => _offsetLabel.text = value.ToString(CultureInfo.InvariantCulture);
        }

        protected virtual void RefreshDigits()
        { }
    }
}