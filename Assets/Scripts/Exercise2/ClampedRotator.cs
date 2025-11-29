using UnityEngine;

namespace Exercise2
{
    public class ClampedRotator : Rotator
    {
        private readonly float _maxRotationAngle;
        private readonly float _minRotationAngle;

        public ClampedRotator(float rotateSpeed, Transform target, float minRotationAngle, float maxRotationAngle) 
            : base(rotateSpeed, target)
        {
            _maxRotationAngle = maxRotationAngle;
            _minRotationAngle = minRotationAngle;
        }

        public override void SetRotationInput(float value)
        {
            base.SetRotationInput(value);
            
            float currentRotation = RotationInput;

            if (currentRotation > 180) 
                currentRotation -= 360;

            currentRotation = Mathf.Clamp(currentRotation, _minRotationAngle, _maxRotationAngle);
            RotationInput = currentRotation;
        }

    }
}
