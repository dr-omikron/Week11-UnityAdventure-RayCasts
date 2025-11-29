using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Exercise1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<CinemachineVirtualCamera> _cameras;
        [SerializeField] private LayerMask _interactableMask;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private ParticleSystem _explosionParticles;

        private CameraSwitcher _cameraSwitcher;
        private Raycaster _raycaster;
        private InputManager _inputManager;

        private IRaycastEffect _dragEffect;
        private IRaycastEffect _explosionEffect;

        private void Awake()
        {
            _cameraSwitcher = new CameraSwitcher(_cameras);
            _raycaster = new Raycaster();
            _inputManager = new InputManager();

            _dragEffect = new DragEffect();
            _explosionEffect = new ExplosionEffect(_explosionRadius, _explosionParticles);
        }

        private void Update()
        {
            UpdateInputActions();
        }

        private void UpdateInputActions()
        {
            if(_inputManager.IsSwitchingCamera)
                _cameraSwitcher.SwitchCamera();

            if (_inputManager.IsDraggingStart)
            {
                _raycaster.SetRaycastEffect(_dragEffect);
                CastRayFromCameraToPrepare(Input.mousePosition, _interactableMask);
            }

            if (_inputManager.IsDragging)
            {
                CastRayFromCameraToExecute(Input.mousePosition, _groundMask);
            }

            if (_inputManager.IsDraggingEnd)
                _raycaster.CastToEndEffect();

            if (_inputManager.IsExplode)
            {
                _raycaster.SetRaycastEffect(_explosionEffect);
                CastRayFromCameraToExecute(Input.mousePosition, _groundMask);
            }
        }

        private void CastRayFromCameraToExecute(Vector3 mousePosition, LayerMask raycastMask)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            _raycaster.CastToExecuteEffect(ray.origin, ray.direction, raycastMask);
        }

        private void CastRayFromCameraToPrepare(Vector3 mousePosition, LayerMask raycastMask)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            _raycaster.CastToPrepareEffect(ray.origin, ray.direction, raycastMask);
        }
    }
}
