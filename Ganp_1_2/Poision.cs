// Decompiled with JetBrains decompiler
// Type: Poision
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Poision : MonoBehaviour
{
  [SerializeField]
  private float moveSpeed;
  private Vector3 dirVec;
  private Player player;
  private TrailRenderer trailRenderer;

  private void Awake()
  {
    this.player = Object.FindObjectOfType<Player>();
    this.trailRenderer = this.GetComponent<TrailRenderer>();
  }

  private void OnEnable()
  {
    this.StartCoroutine("GetDirection");
    this.StartCoroutine(Singleton<PoolManager>.Instance.DestroyObj(this.gameObject, 2.5f));
  }

  private void OnDisable() => this.trailRenderer.emitting = false;

  private void Update() => this.transform.position += this.dirVec * this.moveSpeed * Time.deltaTime;

  private IEnumerator GetDirection()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Poision poision = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      poision.dirVec = (poision.player.transform.position - poision.transform.position).normalized;
      poision.trailRenderer.emitting = true;
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) null;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.transform.CompareTag("HitBox"))
      return;
    Singleton<PlayerHealth>.Instance.PlayerHit();
    Singleton<PoolManager>.Instance.DestroyObj(this.gameObject);
  }
}
