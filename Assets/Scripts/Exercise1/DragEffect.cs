using UnityEngine;

namespace Exercise1
{
    public class DragEffect : IRaycastEffect
    {
        private IDraggable _draggable;

        public void PrepareEffect(Collider hitCollider) => _draggable = hitCollider.GetComponent<IDraggable>();

        public void ExecuteEffect(Vector3 hitPoint, Collider hitCollider)
        {
            if (_draggable != null)
                _draggable.Drag(hitPoint);
        }

        public void EndEffect() => _draggable = null;
    }
}
