using UnityEngine;

namespace Exercise1
{
    public class InputManager
    {
        private const KeyCode SwitchCameraKey = KeyCode.F;
        private const int LeftMouseButtonID = 0;
        private const int RightMouseButtonID = 1;

        public bool IsSwitchingCamera => Input.GetKeyDown(SwitchCameraKey);

        public bool IsDraggingStart => Input.GetMouseButtonDown(LeftMouseButtonID);
        public bool IsDragging => Input.GetMouseButton(LeftMouseButtonID);

        public bool IsDraggingEnd => Input.GetMouseButtonUp(LeftMouseButtonID);
        public bool IsExplode => Input.GetMouseButtonDown(RightMouseButtonID);
    }
}
