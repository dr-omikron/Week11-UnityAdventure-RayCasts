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
        private CameraRaycaster _raycaster;
        private InputManager _inputManager;

        private IRaycastEffect _dragEffect;
        private IRaycastEffect _explosionEffect;

        private void Awake()
        {
            _cameraSwitcher = new CameraSwitcher(_cameras);
            _raycaster = new CameraRaycaster();
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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                _raycaster.StartCast(ray.origin, ray.direction, _interactableMask);
            }

            if (_inputManager.IsDragging)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                _raycaster.Cast(ray.origin, ray.direction, _groundMask);
            }

            if (_inputManager.IsDraggingEnd)
                _raycaster.EndCast();

            if (_inputManager.IsExplode)
            {
                _raycaster.SetRaycastEffect(_explosionEffect);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                _raycaster.Cast(ray.origin, ray.direction, _groundMask);
            }
        }
    }
}
