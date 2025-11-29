
using UnityEngine;

namespace Exercise2
{
    public class Rotator
    {
        private readonly float _rotateSpeed;
        private readonly Transform _target;

        public Rotator(float rotateSpeed, Transform target)
        {
            _rotateSpeed = rotateSpeed;
            _target = target;
        }

        protected float RotationInput { get; set; }

        private Vector3 CurrentRotation => _target.localRotation.eulerAngles;

        public Vector3 TargetForwardDirection => _target.forward;

        public virtual void SetRotationInput(float value)
        {
            RotationInput = value * _rotateSpeed * Time.deltaTime;
            RotationInput += CurrentRotation.y;
        }

        public void RotateAroundUp()
        {
            _target.localEulerAngles = new Vector3(0, RotationInput, 0);
        }
    }
}
