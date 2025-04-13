using UnityEngine;

public class HeadBob : MonoBehaviour
{
    #region Editor Valiable
    [Header("HeadBob Valiables")]
    [HideInInspector] public float _appliedBobbingAmount;
    [HideInInspector] public float _appliedBobbingSpeed = 0.18f;
    [SerializeField] private bool _headbobOn = false;
    private float _timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float runBobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float runBobbingAmount = 0.2f;
    public float midpoint = 1.0f;
    #endregion

    private void Update()
    {
        Headbob(_headbobOn);
    }

    private void Headbob(bool headbobToggle)
    {
        if (headbobToggle)
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");
            float waveslice = 0.0f;
            if (Mathf.Abs(xInput) == 0 && Mathf.Abs(yInput) == 0)
            {
                _timer = 0.0f;
            }
            else
            {
                waveslice = Mathf.Sin(_timer);
                _timer = _timer + _appliedBobbingSpeed;
                if (_timer > Mathf.PI * 2)
                {
                    _timer = _timer - (Mathf.PI * 2);
                }
            }
            Vector3 v3T = transform.localPosition;
            if (waveslice != 0)
            {
                float translateChange = waveslice * _appliedBobbingAmount;
                float totalAxes = Mathf.Abs(xInput) + Mathf.Abs(yInput);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                v3T.y = midpoint + translateChange;
            }
            else
            {
                v3T.y = midpoint;
            }
            transform.localPosition = v3T;
        }
    }
}
