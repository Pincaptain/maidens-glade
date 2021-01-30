using UnityEngine;

namespace Core.Component.Doodad
{
    public abstract class CollidableBehaviour : MonoBehaviour
    {
        protected abstract void OnCollision(GameObject other);

        protected abstract void OnCollisionLeave(GameObject other);

        protected abstract void OnCollisionUpdate(GameObject other);

        private void OnCollisionEnter(Collision other)
        {
            OnCollision(other.gameObject);
        }

        private void OnCollisionStay(Collision other)
        {
            OnCollisionUpdate(other.gameObject);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionLeave(other.gameObject);
        }
    }
}