// Decompiled with JetBrains decompiler
// Type: Player_Move
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Player_Move : MonoBehaviour
{
  [SerializeField]
  private float moveSpeed = 5f;
  private float runSpeed = 8f;
  private float xMin = -6f;
  private float xMax = 28f;
  private float yMin = -20f;
  private float yMax = 4.5f;
  public bool isFlip;
  private Rigidbody2D rigid;
  private Animator animator;
  private SpriteRenderer spriteRenderer;

  private void Awake()
  {
    this.rigid = this.GetComponent<Rigidbody2D>();
    this.animator = this.GetComponent<Animator>();
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
  }

  private void FixedUpdate() => this.Move();

  private void Update()
  {
    this.MoveAnime();
    this.PlayerRun();
    this.PlayerDie();
  }

  private void Move()
  {
    Vector3 vector3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
    vector3 = vector3.normalized;
    this.rigid.velocity = (Vector2) (vector3 * this.moveSpeed);
    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.xMin, this.xMax), Mathf.Clamp(this.transform.position.y, this.yMin, this.yMax), 0.0f);
  }

  private void MoveAnime()
  {
    if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
      this.animator.SetBool("isMove", true);
    else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
      this.animator.SetBool("isMove", false);
    if ((double) this.rigid.velocity.x < 0.0)
    {
      this.spriteRenderer.flipX = true;
      this.isFlip = true;
    }
    else
      this.spriteRenderer.flipX = false;
    this.isFlip = false;
  }

  private void PlayerRun()
  {
    if (Input.GetKey(KeyCode.LeftShift))
    {
      this.moveSpeed = this.runSpeed;
      this.animator.SetBool("isRun", true);
    }
    else
    {
      if (!Input.GetKeyUp(KeyCode.LeftShift))
        return;
      this.moveSpeed = 5f;
      this.animator.SetBool("isRun", false);
    }
  }

  public void PlayerDie()
  {
    if (GameManager.instance.currentPlayerHp > 0)
      return;
    this.animator.SetBool("onDie", true);
    this.moveSpeed = 0.0f;
    this.runSpeed = 0.0f;
  }

  public void DieEvent() => SceneManager.LoadScene("GameOver");
}
