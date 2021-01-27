using UnityEngine;

namespace Core.Component.Doodad
{
    [CreateAssetMenu(fileName = "New Obtainable", menuName = "Inventory/Obtainable")]
    public class Obtainable : ScriptableObject
    {
        public string id;
        public new string name;
        public string description;
    }
}