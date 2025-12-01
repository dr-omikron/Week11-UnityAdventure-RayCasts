using UnityEngine;

namespace Exercise1
{
    [RequireComponent(typeof(Rigidbody))]
    public class ExplodeInteraction : MonoBehaviour, IExplodable
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Explode(Vector3 hitPosition, float force)
        {
            Vector3 impulseDirection = _rigidbody.position - hitPosition;
            _rigidbody.AddForce(impulseDirection * force, ForceMode.Impulse);
        }
    }
}
