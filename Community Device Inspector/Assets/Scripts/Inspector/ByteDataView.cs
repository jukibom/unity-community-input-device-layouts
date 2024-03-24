using JetBrains.Annotations;
using UnityEngine;

namespace CommunityDeviceInspector
{
    public class ByteDataView : MonoBehaviour
    {
        [SerializeField] private Byte _bytePrefab;
        [SerializeField] private Transform _container;

        [CanBeNull] private Byte[] _binaryBytes;
        
        private byte[] _data;
        public byte[] Data
        {
            get => _data;
            set
            {
                _data = value;
                RefreshData();
            }
        }

        private void RefreshData()
        {
            // get number of children in container
            int childCount = _container.childCount;
            if (childCount != _data.Length)
            {
                RebuildContainer();
            }

            if (_binaryBytes != null && _binaryBytes.Length == _data.Length)
            {
                for (var i = 0; i < _data.Length; i ++)
                {
                    _binaryBytes[i].Value = _data[i];
                }
            }
        }

        private void RebuildContainer()
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }

            _binaryBytes = new Byte[_data.Length];
            
            for (int i = 0; i < _data.Length; i++)
            {
                Byte byteVisualisation = Instantiate(_bytePrefab, _container);
                _binaryBytes[i] = byteVisualisation;
                byteVisualisation.Value = _data[i];
                byteVisualisation.Offset = i;
            }
        }
    }

}