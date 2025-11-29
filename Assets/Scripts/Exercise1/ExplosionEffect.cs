using UnityEngine;

namespace Exercise1
{
    public class ExplosionEffect : IRaycastEffect
    {
        private readonly float _explosionRadius;
        private readonly ParticleSystem _explosionParticles;

        public ExplosionEffect(float explosionRadius, ParticleSystem explosionParticles)
        {
            _explosionRadius = explosionRadius;
            _explosionParticles = explosionParticles;
        }

        public void ExecuteEffect(Vector3 hitPoint, Collider hitCollider)
        {
            Collider[] targets = Physics.OverlapSphere(hitPoint, _explosionRadius);

            foreach (Collider target in targets)
            {
                IExplodable explodable = target.GetComponent<IExplodable>();

                if (explodable != null)
                    explodable.Explode(hitPoint);
            }

            Object.Instantiate(_explosionParticles, hitPoint, Quaternion.identity);
        }

        public void StartEffect(Collider hitCollider) { }
        public void EndEffect() { }
    }
}
