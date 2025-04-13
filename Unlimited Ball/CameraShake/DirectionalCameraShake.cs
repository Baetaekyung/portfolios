using UnityEngine;
using Cinemachine;

public class CollisionCameraShake : MonoBehaviour
{
    private BallController _player;

    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _noise;
    private float _shakeTimer;

    [SerializeField] private float _shakeDuration = 0.5f; // ��鸲 ���� �ð�

    private void Awake()
    {
        _player = FindObjectOfType<BallController>();



        // Cinemachine Virtual Camera�� ������
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (_virtualCamera != null)
        {
            _noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_noise != null)
        {
            Debug.Log("�ӵ��� " + _player.RbCompo.velocity.magnitude);

            _noise.m_AmplitudeGain = _player.RbCompo.velocity.magnitude / 3;
            _noise.m_FrequencyGain = _player.RbCompo.velocity.magnitude / 3;

            // ��鸲 Ÿ�̸� ����
            _shakeTimer = _shakeDuration;
        }
    }

    private void Update()
    {
        // ��鸲 Ÿ�̸� ����
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            // Ÿ�̸Ӱ� ������ ��鸲 ��Ȱ��ȭ
            if (_shakeTimer <= 0f && _noise != null)
            {
                _noise.m_AmplitudeGain = 0f;
                _noise.m_FrequencyGain = 0f;
            }
        }
    }
}
