// Decompiled with JetBrains decompiler
// Type: PoolManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PoolManager : Singleton<PoolManager>
{
  public List<PoolData> poolList = new List<PoolData>();

  private void Awake() => this.AddObjectsToPool();

  private void AddObjectsToPool()
  {
    foreach (PoolData pool in this.poolList)
    {
      for (int index = 0; index < pool.initCount; ++index)
      {
        GameObject gameObject = Object.Instantiate<GameObject>(pool.prefeb, this.transform);
        pool.list.Add(gameObject);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
      }
    }
  }

  public GameObject GetSpawn(string prefabName)
  {
    foreach (PoolData pool in this.poolList)
    {
      if (pool.prefeb.name.Equals(prefabName) && pool.list != null)
      {
        foreach (GameObject spawn in pool.list)
        {
          if (!spawn.activeSelf)
          {
            spawn.SetActive(true);
            return spawn;
          }
        }
        GameObject spawn1 = Object.Instantiate<GameObject>(pool.prefeb, this.transform);
        pool.list.Add(spawn1);
        spawn1.transform.localPosition = Vector3.zero;
        spawn1.SetActive(true);
        return spawn1;
      }
    }
    return (GameObject) null;
  }

  public void DestroyObj(GameObject obj)
  {
    obj.transform.localPosition = Vector3.zero;
    obj.SetActive(false);
  }

  public IEnumerator DestroyObj(GameObject obj, float time)
  {
    obj.transform.localPosition = Vector3.zero;
    yield return (object) new WaitForSeconds(time);
    obj.SetActive(false);
  }
}
