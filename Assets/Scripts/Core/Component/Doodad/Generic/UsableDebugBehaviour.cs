using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    /// <summary>
    /// UsableDebugBehaviour is a development class and should not
    /// be used in production.
    /// </summary>
    public class UsableDebugBehaviour : UsableBehaviour
    {
        public override void OnUse()
        {
            Debug.Log("Using");
        }
    }
}