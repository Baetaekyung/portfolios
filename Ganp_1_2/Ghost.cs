// Decompiled with JetBrains decompiler
// Type: Ghost
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Rendering.Universal;

#nullable disable
public class Ghost : MonoBehaviour
{
  private GameObject player;
  [SerializeField]
  private float currentSpeed;
  private Light2D light2d;
  private Vector3 moveDir;

  private void OnEnable() => this.player = Object.FindAnyObjectByType<Player>().gameObject;

  private void Update()
  {
    this.moveDir = this.player.transform.position - this.transform.position;
    this.moveDir = this.moveDir.normalized;
    this.transform.position += this.moveDir * this.currentSpeed * Time.deltaTime;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    this.light2d = collision.GetComponentInChildren<Light2D>();
    this.light2d.intensity -= 0.2f;
    this.Release();
  }

  private void Release() => this.transform.position = this.player.transform.position * 2.5f;
}
