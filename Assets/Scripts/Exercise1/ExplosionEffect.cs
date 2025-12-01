using UnityEngine;

namespace Exercise1
{
    public class ExplosionEffect
    {
        private readonly float _explosionRadius;
        private readonly float _explosionForce;
        private readonly ParticleSystem _explosionParticles;

        public ExplosionEffect(float explosionRadius, float explosionForce, ParticleSystem explosionParticles)
        {
            _explosionRadius = explosionRadius;
            _explosionForce = explosionForce;
            _explosionParticles = explosionParticles;
        }

        public void Explode(Vector3 hitPoint)
        {
            Collider[] targets = Physics.OverlapSphere(hitPoint, _explosionRadius);

            foreach (Collider target in targets)
            {
                IExplodable explodable = target.GetComponent<IExplodable>();

                if (explodable != null)
                    explodable.Explode(hitPoint, _explosionForce);
            }

            Object.Instantiate(_explosionParticles, hitPoint, Quaternion.identity);
        }
    }
}
