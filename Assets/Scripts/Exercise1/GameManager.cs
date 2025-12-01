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
        [SerializeField] private float _explosionForce;
        [SerializeField] private ParticleSystem _explosionParticles;

        private CameraSwitcher _cameraSwitcher;
        private Raycaster _raycaster;
        private InputManager _inputManager;

        private DragEffect _dragEffect;
        private ExplosionEffect _explosionEffect;

        private void Awake()
        {
            _cameraSwitcher = new CameraSwitcher(_cameras);
            _raycaster = new Raycaster();
            _inputManager = new InputManager();

            _dragEffect = new DragEffect();
            _explosionEffect = new ExplosionEffect(_explosionRadius, _explosionForce, _explosionParticles);
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
                if(_raycaster.CastRayFromCamera(Input.mousePosition, _interactableMask, out RaycastHit hit))
                    _dragEffect.PrepareDrag(hit.collider);
            }

            if (_inputManager.IsDragging)
            {
                if(_raycaster.CastRayFromCamera(Input.mousePosition, _groundMask, out RaycastHit hit))
                    _dragEffect.Drag(hit.point);
            }

            if (_inputManager.IsDraggingEnd)
                _dragEffect.EndDrag();

            if (_inputManager.IsExplode)
            {
                if(_raycaster.CastRayFromCamera(Input.mousePosition, _groundMask, out RaycastHit hit))
                    _explosionEffect.Explode(hit.point);
            }
        }
    }
}
