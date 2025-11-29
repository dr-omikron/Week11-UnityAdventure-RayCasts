using UnityEngine;

namespace Exercise1
{
    public interface IRaycastEffect
    {
        void StartEffect(Collider hitCollider);

        void ExecuteEffect(Vector3 hitPoint, Collider hitCollider);

        void EndEffect();
    }
}
