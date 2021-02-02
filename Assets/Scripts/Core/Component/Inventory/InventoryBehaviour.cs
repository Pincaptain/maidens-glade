using System.Collections.Generic;
using Core.Component.Doodad;
using Core.Component.Player;
using Core.Component.UI;
using UnityEngine;

namespace Core.Component.Inventory
{
    public class InventoryBehaviour : MonoBehaviour
    {
        public static InventoryBehaviour Instance { get; private set; }

        private Inventory m_Inventory;
        private InventoryUIBehaviour m_InventoryUIBehaviour;
        private CommonUIBehaviour m_CommonUIBehaviour;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            m_Inventory = new Inventory();
            m_CommonUIBehaviour = CommonUIBehaviour.Instance;
            m_InventoryUIBehaviour = GetComponent<InventoryUIBehaviour>();
        }

        private void Update()
        {
            OnInventory();
        }

        private void OnInventory()
        {
            if (Input.GetKeyDown(Controls.Inventory))
            {
                m_InventoryUIBehaviour.ToggleInventoryText();
            }
        }

        public void AddObtainable(Obtainable obtainable)
        {
            m_Inventory.AddObtainable(obtainable);
            m_CommonUIBehaviour.EnqueueNotification($"Obtained {obtainable.name}");
        }

        public IEnumerable<Obtainable> GetObtainables()
        {
            return m_Inventory.GetObtainables();
        }
    }
}