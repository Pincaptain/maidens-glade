using System;
using System.Collections.Generic;
using Core.Component.Doodad;
using Core.Component.Player;
using Core.Manager;
using UnityEngine;

namespace Core.Component.Inventory
{
    public class InventoryBehaviour : MonoBehaviour
    {
        public static InventoryBehaviour Instance { get; private set; }

        private Inventory m_Inventory;
        private InterfaceManager m_InterfaceManager;

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
            m_InterfaceManager = InterfaceManager.Instance;
        }

        private void Update()
        {
            OnInventory();
        }

        private void OnInventory()
        {
            if (Input.GetKeyDown(Controls.Inventory))
            {
                m_InterfaceManager.ToggleInventoryText();
            }
        }

        public void AddObtainable(Obtainable obtainable)
        {
            m_Inventory.AddObtainable(obtainable);
            m_InterfaceManager.Notify($"Obtained {obtainable.name}");
        }

        public List<Obtainable> GetObtainables()
        {
            return m_Inventory.GetObtainables();
        }
    }
}