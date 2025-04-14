// Decompiled with JetBrains decompiler
// Type: PlayerInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class PlayerInput : MonoBehaviour
{
  public Action<Vector2> onMovementChanged;
  public Action<Vector3> onMouseDirectionChanged;
  public Action<Vector2> onDash;
  public Action onAttack;
  public Action onShield;
  private float horizontal;
  private float vertical;
  public Vector3 moveDirection = Vector3.zero;
  public Vector3 mouseDirection = Vector3.zero;

  private void Update()
  {
    if (Singleton<GameManager>.Instance.isDead)
      return;
    this.MoveInput();
    this.MouseDirInput();
    this.AttackInput();
    this.ShieldInput();
  }

  private void MoveInput()
  {
    this.horizontal = Input.GetAxisRaw("Horizontal");
    this.vertical = Input.GetAxisRaw("Vertical");
    this.moveDirection = new Vector3(this.horizontal, this.vertical, 0.0f).normalized;
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      Action<Vector2> onDash = this.onDash;
      if (onDash != null)
        onDash((Vector2) this.moveDirection);
    }
    Action<Vector2> onMovementChanged = this.onMovementChanged;
    if (onMovementChanged == null)
      return;
    onMovementChanged((Vector2) this.moveDirection);
  }

  private void MouseDirInput()
  {
    this.mouseDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized;
    Action<Vector3> directionChanged = this.onMouseDirectionChanged;
    if (directionChanged == null)
      return;
    directionChanged(this.mouseDirection);
  }

  private void AttackInput()
  {
    if (!Input.GetMouseButtonDown(0))
      return;
    Action onAttack = this.onAttack;
    if (onAttack == null)
      return;
    onAttack();
  }

  private void ShieldInput()
  {
    if (!Input.GetMouseButtonDown(1))
      return;
    Action onShield = this.onShield;
    if (onShield == null)
      return;
    onShield();
  }
}
