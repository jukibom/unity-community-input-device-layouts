using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace CommunityDeviceInspector
{
    public class ByteOffsetDataView : MonoBehaviour
    {
        [SerializeField] private OffsetLabel _offsetLabelPrefab;
        [SerializeField] private Transform _container;

        [CanBeNull] private OffsetLabel[] _binaryBytes;
        
        private int _byteCount;
        public int ByteCount
        {
            get => _byteCount;
            set
            {
                _byteCount = value;
                RefreshData();
            }
        }

        private void RefreshData()
        {
            // get number of children in container
            int childCount = _container.childCount;
            if (childCount != _byteCount)
            {
                RebuildContainer();
            }

            if (_binaryBytes != null && _binaryBytes.Length == _byteCount)
            {
                for (var i = 0; i < _byteCount; i ++)
                {
                    _binaryBytes[i].Offset = i;
                }
            }
        }

        private void RebuildContainer()
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }

            _binaryBytes = new OffsetLabel[_byteCount];
            
            for (int i = 0; i < _byteCount; i++)
            {
                OffsetLabel byteVisualisation = Instantiate(_offsetLabelPrefab, _container);
                _binaryBytes[i] = byteVisualisation;
                byteVisualisation.Offset = i;
            }
        }
    }

}