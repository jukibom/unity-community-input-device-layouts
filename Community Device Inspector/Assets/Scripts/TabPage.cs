using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace CommunityDeviceInspector
{
    [Serializable]
    public class TabGroup
    {
        public Button Tab;
        public GameObject Page;
    }
    
    public class TabPage : MonoBehaviour
    {
        [SerializeField] private List<TabGroup> _tabGroups;
        [SerializeField] private Color _tabButtonColor = Color.white;
        [SerializeField] private Color _selectedTabButtonColor = Color.white;

        [CanBeNull] private TabGroup _activeTabGroup;
        
        private void Start()
        {
            if (_tabGroups.Count <= 0) return;
            
            // init tab color, page visibility, and add click handlers
            foreach (var tabGroup in _tabGroups)
            {
                tabGroup.Page.SetActive(false);
                tabGroup.Tab.image.color = _tabButtonColor;
                tabGroup.Tab.onClick.AddListener(() => Show(tabGroup));
            }

            Show(_tabGroups.First());
        }

        private void Show(TabGroup tabGroup)
        {
            if (_activeTabGroup != null)
            {
                _activeTabGroup.Tab.image.color = _tabButtonColor;
                _activeTabGroup.Page.SetActive(false);
            }
            tabGroup.Page.SetActive(true);
            tabGroup.Tab.image.color = _selectedTabButtonColor;
            
            _activeTabGroup = tabGroup;
        }
    }
}