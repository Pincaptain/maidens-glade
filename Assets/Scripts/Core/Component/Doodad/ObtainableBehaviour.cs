using UnityEngine;

namespace Core.Component.Doodad
{
    public abstract class ObtainableBehaviour : MonoBehaviour
    {
        [SerializeField] protected Obtainable obtainable;

        public abstract void OnObtain();
    }
}