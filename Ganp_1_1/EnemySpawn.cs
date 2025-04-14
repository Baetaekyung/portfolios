// Decompiled with JetBrains decompiler
// Type: EnemySpawn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class EnemySpawn : MonoBehaviour
{
  [SerializeField]
  private GameObject enemyPrefab;
  [SerializeField]
  private GameObject RangePrefab;
  [SerializeField]
  private float delayTime = 1.6f;
  private float minDelayTime = 0.2f;
  private float currentTime;
  private float limitTime = 30f;

  private void Start()
  {
    this.StartCoroutine("SpawnEnemy");
    this.StartCoroutine("SpawnRange");
  }

  private void Update() => this.MinusDelayTime();

  private IEnumerator SpawnEnemy()
  {
    EnemySpawn enemySpawn = this;
    while (true)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(enemySpawn.enemyPrefab);
      int index = Random.Range(0, enemySpawn.transform.childCount);
      gameObject.transform.position = enemySpawn.transform.GetChild(index).position;
      yield return (object) new WaitForSeconds(enemySpawn.delayTime);
    }
  }

  private IEnumerator SpawnRange()
  {
    EnemySpawn enemySpawn = this;
    while (true)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(enemySpawn.RangePrefab);
      int index = Random.Range(0, enemySpawn.transform.childCount);
      gameObject.transform.position = enemySpawn.transform.GetChild(index).position;
      yield return (object) new WaitForSeconds(enemySpawn.delayTime + 1f);
    }
  }

  private void MinusDelayTime()
  {
    this.currentTime += Time.deltaTime;
    if ((double) this.currentTime > (double) this.limitTime)
    {
      this.delayTime -= 0.4f;
      this.currentTime = 0.0f;
    }
    if ((double) this.delayTime > (double) this.minDelayTime)
      return;
    this.delayTime = this.minDelayTime;
  }
}
