using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCamera : Equipment
{
    [Header("Player Input")]
    [SerializeField] private PlayerInput _input;

    [Header("About Camera")]
    [SerializeField] private LayerMask _interatableObjectLayer;
    [SerializeField] private LayerMask _boatLayer;
    [SerializeField] private Light _cameraFlashLight;
    [SerializeField] private Light _cameraFlashLightForward;
    [SerializeField] private float _cameraForwardLightIntensity;
    [SerializeField] private float _cameraFlashIntensity;
    private Camera _captureCam;
    private float _cameraForwardDefaultIntensity;
    private bool _canCapture = true;

    private ICaptureable _horrorObject;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _input.OnFire += Capture;
    }

    private void OnDisable()
    {
        _input.OnFire -= Capture;
    }

    private void Init()
    {
        _captureCam = GetComponent<Camera>();
        _cameraForwardDefaultIntensity = _cameraFlashLightForward.intensity;
    }

    private void Update()
    {
        CameraFlashReturnToDefaultIntensity();
        PointOnGhostObject();
        PointBoatToGameOut();
    }

    private void PointOnGhostObject()
    {
        Ray ray = new Ray(_captureCam.transform.position, _captureCam.transform.forward * 100f);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _interatableObjectLayer))
        {
            if (hit.transform.TryGetComponent(out ICaptureable cap))
            {
                _horrorObject = cap;
                _horrorObject.GetPointed();
            }
            else return;
        }
        else
        {
            if (_horrorObject != null)
            {
                _horrorObject.OutPointed();
                _horrorObject = null;
            }
        }
    }

    private void PointBoatToGameOut()
    {
        Ray ray = new Ray(_captureCam.transform.position, _captureCam.transform.forward * 100f);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _boatLayer))
        {
            if(hit.transform.TryGetComponent<Boat>(out Boat b))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    b.GameClear();
                }
            }
            else
            {
                return;
            }
        }
    }

    private void Capture()
    {
        if (_canCapture)
        {
            _canCapture = false;
            StartCoroutine(CaptureCoolRoutine());
            if (_horrorObject != null)
            {
                _horrorObject.Captured();
                _horrorObject = null;
            }
        }
    }

    private void CameraFlashReturnToDefaultIntensity()
    {
        if (_canCapture)
        {
            _cameraFlashLight.intensity = Mathf.Lerp(_cameraFlashLight.intensity, 0f, Time.deltaTime * 30f);
            _cameraFlashLightForward.intensity = Mathf.Lerp(
                _cameraFlashLightForward.intensity, _cameraForwardDefaultIntensity, Time.deltaTime * 30f);
        }
    }

    private IEnumerator CaptureCoolRoutine()
    {
        float t = 0.2f;
        float currentTime = 0f;
        while (currentTime < t)
        {
            currentTime += Time.deltaTime;
            _cameraFlashLight.intensity =
                Mathf.Lerp(
                _cameraFlashLight.intensity,
                _cameraFlashIntensity,
                currentTime / t);

            _cameraFlashLightForward.intensity =
                Mathf.Lerp(
                _cameraFlashLightForward.intensity,
                _cameraForwardLightIntensity,
                currentTime / t);

            yield return null;
        }
        _canCapture = true;
    }
}
