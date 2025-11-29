using UnityEngine;

namespace Exercise2
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Wind _wind;
        [SerializeField] private Transform _mast;

        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private float _maxMastRotationAngle;
        [SerializeField] private float _minMastRotationAngle;

        private Rotator _shipRotator;
        private ClampedRotator _mastRotator;
        private WindMover _windMover;

        private void Awake()
        {
            _windMover = new WindMover(transform,_movementSpeed);
            _shipRotator = new Rotator(_rotationSpeed, transform);
            _mastRotator = new ClampedRotator(_rotationSpeed, _mast,_minMastRotationAngle, _maxMastRotationAngle);
        }

        private void Update()
        {
            UpdateRotators();
            _windMover.Move(_wind.Direction, _mastRotator.TargetForwardDirection);
        }

        private void UpdateRotators()
        {
            if(Mathf.Abs(_playerInput.HorizontalAxisInput) > 0)
            {
                _shipRotator.SetRotationInput(_playerInput.HorizontalAxisInput);
                _shipRotator.RotateAroundUp();
            }

            if(Mathf.Abs(_playerInput.HorizontalExtraInput) > 0)
            {
                _mastRotator.SetRotationInput(_playerInput.HorizontalExtraInput);
                _mastRotator.RotateAroundUp();
            }
        }
    }
}
