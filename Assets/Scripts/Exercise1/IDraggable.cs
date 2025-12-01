using UnityEngine;

namespace Exercise1
{
    public interface IDraggable
    {
        void StartDrag();

        void Drag(Vector3 hitPosition);

        void EndDrag();
    }
}
