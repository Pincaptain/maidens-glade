using Core.Component.Doodad;
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

        public void AddObtainable(Obtainable obtainable)
        {
            m_Inventory.AddObtainable(obtainable);
            m_InterfaceManager.Notify($"Obtained {obtainable.name}");
        }
    }
}