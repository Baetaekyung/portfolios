// Decompiled with JetBrains decompiler
// Type: EnemyDie
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EnemyDie : MonoBehaviour
{
  [SerializeField]
  private GameObject explosionPrefab;
  [SerializeField]
  private GameObject HpItem;
  [SerializeField]
  private GameObject PowerUpItem;
  [SerializeField]
  private int damage = 10;
  [SerializeField]
  private int enemyHp = 2;
  private int scorelimit = 2;
  private int score;
  private int HpdropPer = 1;
  private int PowerDropPer = 2;
  private float limitTime = 30f;
  private float limitCurTIme;
  private float delayTime = 0.5f;
  private float currentTime = 0.5f;

  private void Update()
  {
    this.score = this.scorelimit * 100;
    this.EnemyHpUp();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.CompareTag("Bullet"))
      return;
    Object.Instantiate<GameObject>(this.explosionPrefab, this.transform.position, Quaternion.identity);
    this.enemyHp -= GameManager.instance.PlayerDmg;
    this.Enemydie();
    Object.Destroy((Object) collision.gameObject);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    this.currentTime += Time.deltaTime;
    if ((double) this.currentTime <= (double) this.delayTime)
      return;
    GameManager.instance.PlayerHit(this.damage);
    this.currentTime = 0.0f;
  }

  private void Enemydie()
  {
    if (this.enemyHp > 0)
      return;
    GameManager.instance.ScoreUp(this.score);
    int num1 = Random.Range(0, 33);
    int num2 = Random.Range(0, 500);
    int hpdropPer = this.HpdropPer;
    if (num1 == hpdropPer)
      Object.Instantiate<GameObject>(this.HpItem, this.transform.position, Quaternion.identity);
    if (num2 == this.PowerDropPer)
      Object.Instantiate<GameObject>(this.PowerUpItem, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }

  private void EnemyHpUp()
  {
    this.limitCurTIme += Time.deltaTime;
    if ((double) this.limitCurTIme <= (double) this.limitTime)
      return;
    if (this.enemyHp >= 10)
      this.enemyHp = 10;
    else
      this.enemyHp += 2;
    if (this.scorelimit >= 10)
      this.scorelimit = 10;
    else
      this.scorelimit += 2;
    this.limitCurTIme = 0.0f;
  }
}
