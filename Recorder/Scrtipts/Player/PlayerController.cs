using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float Gravity = -9.81f;

    [Header("UI")]
    [SerializeField] private GameObject _cameraFrameImage;
    [SerializeField] private CanvasGroup _ui;

    [Header("Player Input")]
    [SerializeField] private PlayerInput _input;

    [Header("Move Valiables")]
    [SerializeField] private Transform _spawnTrm;
    public float coldMultiplierValue = 1f;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityMultiplier = 1;
    [SerializeField] private Transform _camPivot;
    private float _appliedSpeed;
    private float _xRotation;
    private float _yRotation;
    private Vector3 _movement;

    [Header("Equipments")]
    public Recorder recorder;
    public CaptureCamera captureCam;

    [Header("Components")]
    [SerializeField] private HeadBob _headBob;
    private CharacterController _cC;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _cC = GetComponent<CharacterController>();

        transform.position = _spawnTrm.position;
        _appliedSpeed = _moveSpeed;
    }

    private void OnEnable()
    {
        _input.OnMovementChanged += Move;
        _input.OnMouseChanged += RotatePlayer;
        _input.OnRunning += Run;
        _input.OnUIOpen += UIOpen;
    }

    private void OnDisable()
    {
        _input.OnMovementChanged -= Move;
        _input.OnMouseChanged -= RotatePlayer;
        _input.OnRunning -= Run;
        _input.OnUIOpen -= UIOpen;
    }

    private void Update()
    {
        if (CursorManager.Instance.uiMode) return;

        _movement.y += Gravity * _gravityMultiplier * Time.deltaTime;
        _cC.Move(transform.rotation * _movement * Time.deltaTime * _appliedSpeed * coldMultiplierValue);
    }

    private void Move(Vector2 moveDirection)
    {
        if (_cC.isGrounded)
        {
            _movement = new Vector3(moveDirection.x, 0, moveDirection.y);
        }
    }

    private void RotatePlayer(Vector2 mouseChangedVec)
    {
        float xInput = mouseChangedVec.x * _rotateSpeed * Time.deltaTime * 10;
        float yInput = mouseChangedVec.y * _rotateSpeed * Time.deltaTime;

        _yRotation += xInput;
        _xRotation += -yInput * _rotateSpeed;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 40f);

        _camPivot.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    private void Run(bool isRun)
    {
        if (isRun)
        {
            _headBob._appliedBobbingAmount = _headBob.runBobbingAmount;
            _headBob._appliedBobbingSpeed = _headBob.runBobbingSpeed;
            _appliedSpeed = _runSpeed;
        }
        else
        {
            _headBob._appliedBobbingAmount = _headBob.bobbingAmount;
            _headBob._appliedBobbingSpeed = _headBob.bobbingSpeed;
            _appliedSpeed = _moveSpeed;
        }
    }

    private void UIOpen()
    {
        if (CursorManager.Instance.uiMode)
        {
            CursorManager.Instance.uiMode = false;
            CursorManager.Instance.SetCursorVisibleFalse();
            UIManager.Instance.PanelOff(_ui, 0.3f);
            _cameraFrameImage.SetActive(true);
        }
        else
        {
            CursorManager.Instance.uiMode = true;
            _cameraFrameImage.SetActive(false);
            CursorManager.Instance.SetCursorVisibleTrue();
            UIManager.Instance.PanelOn(_ui, 0.3f);
        }
    }
}
