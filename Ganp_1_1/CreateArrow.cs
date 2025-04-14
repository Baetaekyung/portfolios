// Decompiled with JetBrains decompiler
// Type: CreateArrow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CreateArrow : MonoBehaviour
{
  public GameObject ArrowPrefab;
  private float delayTime = 1f;
  private float currentTime;

  private void Start()
  {
  }

  private void Update() => this.InstantArrow();

  private void InstantArrow()
  {
    this.currentTime += Time.deltaTime;
    if ((double) this.currentTime <= (double) this.delayTime)
      return;
    Object.Instantiate<GameObject>(this.ArrowPrefab, this.transform.position, Quaternion.identity);
    this.currentTime = 0.0f;
  }
}
