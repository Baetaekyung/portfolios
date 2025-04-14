// Decompiled with JetBrains decompiler
// Type: PlayerController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
  [SerializeField]
  public float dashCooltime;
  [SerializeField]
  private float playerMoveSpeed;
  [SerializeField]
  private float dashSpeed;
  [SerializeField]
  private float dashIvitime;
  private Vector3 pMinusScale;
  public bool canDash;
  private WaitForSeconds dashWfs;
  private WaitForSeconds dashIvi;
  private PlayerInput inputs;
  private Rigidbody2D myRigid;

  private void Awake()
  {
    this.inputs = this.GetComponent<PlayerInput>();
    this.myRigid = this.GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    this.pMinusScale = new Vector3(-1f, 1f, 1f);
    this.dashWfs = new WaitForSeconds(this.dashCooltime);
    this.dashIvi = new WaitForSeconds(this.dashIvitime);
    this.canDash = true;
  }

  private void OnEnable()
  {
    this.inputs.onMovementChanged += new Action<Vector2>(this.PlayerMovement);
    this.inputs.onMouseDirectionChanged += new Action<Vector3>(this.FaceMouseDir);
  }

  private void OnDestroy()
  {
    this.inputs.onMovementChanged -= new Action<Vector2>(this.PlayerMovement);
    this.inputs.onMouseDirectionChanged -= new Action<Vector3>(this.FaceMouseDir);
  }

  private void Update() => this.PlayerDash();

  private void PlayerMovement(Vector2 direction)
  {
    this.myRigid.velocity = direction * this.playerMoveSpeed;
  }

  private void FaceMouseDir(Vector3 mouseDir)
  {
    Vector3 vector3 = Vector3.Cross(Vector3.up, mouseDir);
    if ((double) vector3.z < 0.0)
    {
      this.transform.localScale = Vector3.one;
    }
    else
    {
      if ((double) vector3.z <= 0.0)
        return;
      this.transform.localScale = this.pMinusScale;
    }
  }

  private void PlayerDash()
  {
    if (!Input.GetKeyDown(KeyCode.LeftShift) || !this.canDash)
      return;
    this.canDash = false;
    Singleton<DashSkillCoolTime>.Instance.currentCool = 0.0f;
    Singleton<GameManager>.Instance.isInvisible = 1;
    this.StartCoroutine("CanDashRoutine");
    this.StartCoroutine("DashIvisibleRoutine");
    this.myRigid.DOMove((Vector2) (this.transform.position + this.inputs.moveDirection * this.dashSpeed), 0.3f);
  }

  private IEnumerator CanDashRoutine()
  {
    yield return (object) this.dashWfs;
    this.canDash = true;
  }

  private IEnumerator DashIvisibleRoutine()
  {
    yield return (object) this.dashIvi;
    Singleton<GameManager>.Instance.isInvisible = 0;
  }
}
