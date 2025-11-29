using UnityEngine;

namespace Exercise2
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string HorizontalExtra = "HorizontalExtra";
        public float HorizontalAxisInput { get; private set; }
        public float HorizontalExtraInput { get; private set; }
        private void Update()
        {
            HorizontalAxisInput = Input.GetAxis(HorizontalAxis);
            HorizontalExtraInput = Input.GetAxis(HorizontalExtra);
        }
    }
}
