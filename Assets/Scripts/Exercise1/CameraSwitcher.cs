using System.Collections.Generic;
using Cinemachine;

namespace Exercise1
{
    public class CameraSwitcher
    {
        private readonly Queue<CinemachineVirtualCamera> _switchQueue;
        private readonly List<CinemachineVirtualCamera> _cameras;

        public CameraSwitcher(List<CinemachineVirtualCamera> cameras)
        {
            _cameras = cameras;
            _switchQueue = new Queue<CinemachineVirtualCamera>(_cameras);
            SwitchCamera();
        }

        public void SwitchCamera()
        {
            CinemachineVirtualCamera activeCamera = _switchQueue.Dequeue();

            foreach (CinemachineVirtualCamera camera in _cameras)
                camera.gameObject.SetActive(false);

            activeCamera.gameObject.SetActive(true);
            _switchQueue.Enqueue(activeCamera);
        }
    }
}
