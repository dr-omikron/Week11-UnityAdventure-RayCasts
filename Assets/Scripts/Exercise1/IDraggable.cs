using UnityEngine;

namespace Exercise1
{
    public interface IDraggable
    {
        void StartDrag(Vector3 hitPosition);

        void Drag(Vector3 hitPosition);

        void EndDrag(Vector3 hitPosition);
    }
}
