using System.Text;
using Core.Component.Inventory;
using TMPro;
using UnityEngine;

namespace Core.Component.UI
{
    public class InventoryUIBehaviour : MonoBehaviour
    {
        private TMP_Text m_InventoryText;
        private InventoryBehaviour m_InventoryBehaviour;

        private void Start()
        {
            m_InventoryText = GameObject.Find("InventoryText").GetComponent<TMP_Text>();
            m_InventoryBehaviour = InventoryBehaviour.Instance;
        }
        
        public void ToggleInventoryText()
        {
            if (m_InventoryText.text.Equals(string.Empty))
            {
                var stringBuilder = new StringBuilder();

                foreach (var obtainable in m_InventoryBehaviour.GetObtainables())
                {
                    stringBuilder.AppendLine($"{obtainable.name} x1");
                }

                m_InventoryText.text = stringBuilder.ToString();
            }
            else
            {
                m_InventoryText.text = string.Empty;
            }
        }
    }
}