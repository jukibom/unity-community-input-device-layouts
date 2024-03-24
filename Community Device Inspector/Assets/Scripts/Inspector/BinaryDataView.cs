using JetBrains.Annotations;
using UnityEngine;

namespace CommunityDeviceInspector
{
    public class BinaryDataView : MonoBehaviour
    {
        [SerializeField] private BinaryByte _binaryBytePrefab;
        [SerializeField] private Transform _container;

        [CanBeNull] private BinaryByte[] _binaryBytes;
        
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

            _binaryBytes = new BinaryByte[_data.Length];
            
            for (int i = 0; i < _data.Length; i++)
            {
                BinaryByte binaryByte = Instantiate(_binaryBytePrefab, _container);
                _binaryBytes[i] = binaryByte;
                binaryByte.Value = _data[i];
                binaryByte.Offset = i;
            }
        }
    }

}