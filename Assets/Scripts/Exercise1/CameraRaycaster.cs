using UnityEngine;

namespace Exercise1
{
    public class CameraRaycaster
    {
        private IRaycastEffect _currentEffect;

        public void SetRaycastEffect(IRaycastEffect raycastEffect) => _currentEffect = raycastEffect;

        public void StartCast(Vector3 origin, Vector3 direction, LayerMask mask)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, mask.value))
                _currentEffect.StartEffect(hit.collider);
        }

        public void Cast(Vector3 origin, Vector3 direction, LayerMask mask)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, mask.value))
                _currentEffect.ExecuteEffect(hit.point, hit.collider);
        }

        public void EndCast()
        {
            _currentEffect.EndEffect();
        }
    }
}
