using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace CommunityDeviceInspector
{
    public class Byte : MonoBehaviour
    {

        [SerializeField] protected List<Digit> _digits;

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

        protected virtual void RefreshDigits()
        { }
    }
}