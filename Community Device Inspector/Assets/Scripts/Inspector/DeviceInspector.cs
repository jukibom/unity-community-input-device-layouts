using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CommunityDeviceInspector
{
    public class DeviceInspector : MonoBehaviour
    {
        [SerializeField] private ByteOffsetDataView _offsetDataView;
        [SerializeField] private List<ByteDataView> _dataViews;

        private InputFrame _state;

        public InputFrame DeviceData
        {
            get => _state;
            set
            {
                _state = value;
                RefreshDataVisualisation();
            }
        }

        private void RefreshDataVisualisation()
        {
            _offsetDataView.ByteCount = _state.rawBytes.Length;
            foreach (var byteDataView in _dataViews)
            {
                byteDataView.Data = _state.rawBytes;
            }
        }
    }
}