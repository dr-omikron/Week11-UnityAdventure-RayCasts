using UnityEngine;

namespace Exercise2
{
    public class WindIndicator : MonoBehaviour
    {
        [SerializeField] private Wind _wind;

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(_wind.Direction);
        }
    }
}
