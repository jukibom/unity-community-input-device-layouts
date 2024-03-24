using UnityEngine;

namespace CommunityDeviceInspector
{
    public class DeviceInspector : MonoBehaviour
    {
        [SerializeField] private BinaryDataView _binaryDataView;

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
            _binaryDataView.Data = _state.rawBytes;
        }
    }
}