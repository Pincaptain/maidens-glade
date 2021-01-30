using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    public class CollidableDebugBehaviour : CollidableBehaviour
    {
        protected override void OnCollision(GameObject other)
        {
            Debug.Log($"Collision: {other.name}");
        }

        protected override void OnCollisionLeave(GameObject other)
        {
            Debug.Log($"Collision Leave: {other.name}");
        }

        protected override void OnCollisionUpdate(GameObject other)
        {
            Debug.Log($"Colliding: {other.name}");
        }
    }
}