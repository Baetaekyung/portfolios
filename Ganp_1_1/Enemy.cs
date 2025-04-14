// Decompiled with JetBrains decompiler
// Type: Enemy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Enemy : MonoBehaviour
{
  private GameObject player;
  [SerializeField]
  private float followSpeed = 4f;
  private SpriteRenderer spriterenderer;

  private void Awake()
  {
    this.player = GameObject.FindWithTag("Player");
    this.spriterenderer = this.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    this.FollowPlayer();
    this.FlipX();
  }

  private void FollowPlayer()
  {
    this.transform.position += (this.player.transform.position - this.transform.position).normalized * this.followSpeed * Time.deltaTime;
  }

  private void FlipX()
  {
    if ((double) this.player.transform.position.x < (double) this.transform.position.x)
      this.spriterenderer.flipX = true;
    else
      this.spriterenderer.flipX = false;
  }
}
