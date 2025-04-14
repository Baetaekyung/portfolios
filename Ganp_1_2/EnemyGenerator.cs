// Decompiled with JetBrains decompiler
// Type: EnemyGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EnemyGenerator : Singleton<EnemyGenerator>
{
  [SerializeField]
  private GameObject[] enemies;
  [SerializeField]
  private int maximumEnemy;
  [SerializeField]
  private int minimumEnemy;
  [SerializeField]
  private GameObject ghost;

  private void Start()
  {
  }

  public void EnemySpawn(Vector3 spawnPos)
  {
    int num = Random.Range(this.minimumEnemy, this.maximumEnemy);
    if (Random.Range(0, 6) != 3)
      return;
    for (int index = 0; index < num; ++index)
    {
      Object.Instantiate<GameObject>(this.enemies[Random.Range(0, 2)], spawnPos, Quaternion.identity);
      ++Singleton<GameManager>.Instance.leftMonster;
    }
  }
}
