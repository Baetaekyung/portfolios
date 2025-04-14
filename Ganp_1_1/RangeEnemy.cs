// Decompiled with JetBrains decompiler
// Type: RangeEnemy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RangeEnemy : MonoBehaviour
{
  [SerializeField]
  private float followSpeed = 3.5f;
  private GameObject Player;
  private SpriteRenderer spriterenderer;
  private Vector3 dirVec;

  private void Start()
  {
    this.Player = GameObject.FindWithTag("Player");
    this.spriterenderer = this.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    this.SetDir();
    this.FlipX();
  }

  private void SetDir()
  {
    this.dirVec = (this.Player.transform.position - this.transform.position).normalized;
    this.transform.position += this.dirVec * this.followSpeed * Time.deltaTime;
  }

  private void FlipX()
  {
    if ((double) this.Player.transform.position.x < (double) this.transform.position.x)
      this.spriterenderer.flipX = true;
    else
      this.spriterenderer.flipX = false;
  }
}
