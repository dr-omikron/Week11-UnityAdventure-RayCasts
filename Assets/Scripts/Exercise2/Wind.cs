using UnityEngine;
using Random = UnityEngine.Random;

namespace Exercise2
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private float _timeToChangeDirection;
        private Vector3 _newDirection;

        private float _timer;

        public Vector3 Direction { get; private set; }

        private void Awake()
        {
            SetNewDirection();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToChangeDirection)
            {
                SetNewDirection();
                _timer = 0;
            }

            LerpDirections();
        }

        private void LerpDirections()
        {
            Direction = Vector3.Lerp(Direction, _newDirection, Time.deltaTime);
        }

        private void SetNewDirection()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            _newDirection = new Vector3(randomDirection.x, 0, randomDirection.y);
        }
    }
}
