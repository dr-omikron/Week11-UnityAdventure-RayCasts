using UnityEngine;

namespace Exercise2
{
    public class WindMover
    {
        private readonly Transform _movementTarget;

        private readonly float _moveSpeed;

        public WindMover(Transform movementTarget, float moveSpeed)
        {
            _movementTarget = movementTarget;
            _moveSpeed = moveSpeed;
        }

        public void Move(Vector3 windDirection, Vector3 windCatcherForwardDirection)
        {
            float windForce = Vector3.Dot(windCatcherForwardDirection, windDirection);
            float moveForce = Vector3.Dot(windCatcherForwardDirection, _movementTarget.forward);

            windForce = Mathf.Clamp(windForce, 0, 1f);
            moveForce = Mathf.Clamp(moveForce, 0, 1f);

            float movement = windForce * moveForce * _moveSpeed * Time.deltaTime;
            _movementTarget.transform.position += _movementTarget.forward * movement; 
        }
    }
}
