// Decompiled with JetBrains decompiler
// Type: bullet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bullet : MonoBehaviour
{
  [SerializeField]
  private float power = 3f;
  private Camera cam;
  private Rigidbody2D bulletRigid;
  private Vector2 mouseDir;

  private void Awake() => this.bulletRigid = this.GetComponent<Rigidbody2D>();

  private void Start()
  {
    Object.Destroy((Object) this.gameObject, 1f);
    this.cam = Camera.main;
    this.SetDir();
  }

  private void Update() => this.Shotted();

  private void SetDir()
  {
    this.mouseDir = (Vector2) this.cam.ScreenToWorldPoint(Input.mousePosition) - (Vector2) this.transform.position;
    this.mouseDir = this.mouseDir.normalized;
  }

  private void Shotted()
  {
    this.bulletRigid.AddForce(this.mouseDir * this.power, ForceMode2D.Impulse);
  }
}
