using UnityEngine;
using TMPro;

namespace CommunityDeviceInspector
{
    public class Digit : MonoBehaviour
    {
        [SerializeField] private Color _digitColor = Color.white;
        [SerializeField] private Color _digitChangedColor = Color.red;
        [SerializeField] private TMP_Text _digitLabel;
        
        public string Value
        {
            get => _digitLabel.text;
            set
            {
                if (_digitLabel.text != value)
                {
                    _digitLabel.color = _digitChangedColor;
                }
                _digitLabel.text = value;
            }
        }
        
        private void Update()
        {
            _digitLabel.color = Color.Lerp(_digitLabel.color, _digitColor, Time.deltaTime);
        }
    }

}