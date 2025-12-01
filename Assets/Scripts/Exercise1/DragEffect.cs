using UnityEngine;

namespace Exercise1
{
    public class DragEffect
    {
        private IDraggable _draggable;

        public void PrepareDrag(Collider hitCollider)
        {
            _draggable = hitCollider.GetComponent<IDraggable>();

            if (_draggable != null)
                _draggable.StartDrag();
        }

        public void Drag(Vector3 hitPoint)
        {
            if (_draggable != null)
                _draggable.Drag(hitPoint);
        }

        public void EndDrag()
        {
            _draggable.EndDrag();
            _draggable = null;
        }
    }
}
