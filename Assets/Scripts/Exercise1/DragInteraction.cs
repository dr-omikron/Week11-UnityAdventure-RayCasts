using UnityEngine;

namespace Exercise1
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragInteraction : MonoBehaviour, IDraggable
    {
        private const float DragYPosition = 1f;
        private Rigidbody _rigidbody;
        private Vector3 _previousHitPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void StartDrag()
        {
            _rigidbody.isKinematic = true;
        }

        public void Drag(Vector3 hitPosition)
        {
            Vector3 movePosition = new Vector3(hitPosition.x, DragYPosition, hitPosition.z);
            _rigidbody.MovePosition(movePosition);
        }

        public void EndDrag()
        {
            _rigidbody.isKinematic = false;
        }
    }
}
