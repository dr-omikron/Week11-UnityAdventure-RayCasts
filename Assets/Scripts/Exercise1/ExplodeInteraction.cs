using UnityEngine;

namespace Exercise1
{
    [RequireComponent(typeof(Rigidbody))]
    public class ExplodeInteraction : MonoBehaviour, IExplodable
    {
        [SerializeField] private float _explosionForce = 5;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Explode(Vector3 hitPosition)
        {
            Vector3 impulseDirection = _rigidbody.position - hitPosition;
            _rigidbody.AddForce(impulseDirection * _explosionForce, ForceMode.Impulse);
        }
    }
}
