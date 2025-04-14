// Decompiled with JetBrains decompiler
// Type: Enemy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Enemy : MonoBehaviour
{
  [SerializeField]
  private GameObject boss;
  public int hp;
  public float speed;
  public bool isDead;
  public bool playerFind;
  public Vector2 dirVec;
  public GameObject[] items;

  public void Ai(float speed, Rigidbody2D rigid, int r, int u)
  {
    if (this.isDead)
      return;
    switch (r)
    {
      case 0:
        this.dirVec += Vector2.right;
        break;
      case 1:
        this.dirVec += Vector2.left;
        break;
    }
    switch (u)
    {
      case 0:
        this.dirVec += Vector2.up;
        break;
      case 1:
        this.dirVec += Vector2.down;
        break;
    }
    rigid.velocity = this.dirVec.normalized * speed;
  }

  public void GenerateBoss(Transform t)
  {
    if (Singleton<GameManager>.Instance.bossAppear || Singleton<GameManager>.Instance.leftMonster != 1)
      return;
    Object.Instantiate<GameObject>(this.boss, t.transform.position, Quaternion.identity);
    Singleton<GameManager>.Instance.bossAppear = true;
  }

  public void FindPlayer(Transform playerTransform, Rigidbody2D rigid)
  {
    this.playerFind = true;
    Vector3 normalized = (playerTransform.position - this.transform.position).normalized;
    rigid.velocity = (Vector2) (normalized * this.speed);
  }

  public void DropHeart(Transform t)
  {
    if (Random.Range(0, 10) != 0)
      return;
    Object.Instantiate<GameObject>(this.items[Random.Range(0, this.items.Length)], t.position, Quaternion.identity);
  }
}
