using UnityEngine;

namespace Exercise1
{
    public class Raycaster
    {
        private IRaycastEffect _currentEffect;

        public void SetRaycastEffect(IRaycastEffect raycastEffect) => _currentEffect = raycastEffect;

        public void CastToPrepareEffect(Vector3 origin, Vector3 direction, LayerMask mask)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, mask.value))
                _currentEffect.PrepareEffect(hit.collider);
        }

        public void CastToExecuteEffect(Vector3 origin, Vector3 direction, LayerMask mask)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, mask.value))
                _currentEffect.ExecuteEffect(hit.point, hit.collider);
        }

        public void CastToEndEffect()
        {
            _currentEffect.EndEffect();
        }
    }
}
