using System.Globalization;
using TMPro;
using UnityEngine;

namespace CommunityDeviceInspector
{
    public class OffsetLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _offsetLabel;

        public int Offset
        {
            get => int.Parse(_offsetLabel.text);
            set => _offsetLabel.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}