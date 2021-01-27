using System.Collections.Generic;
using Core.Component.Doodad;

namespace Core.Component.Inventory
{
    public class Inventory
    {
        private readonly List<Obtainable> m_Obtainables;

        public Inventory()
        {
            m_Obtainables = new List<Obtainable>();
        }

        public void AddObtainable(Obtainable obtainable)
        {
            m_Obtainables.Add(obtainable);
        }

        public void RemoveObtainable(Obtainable obtainable)
        {
            m_Obtainables.Remove(obtainable);
        }

        public bool ContainsObtainable(Obtainable obtainable)
        {
            return m_Obtainables.Contains(obtainable);
        }

        public List<Obtainable> GetObtainables()
        {
            return m_Obtainables;
        }
    }
}