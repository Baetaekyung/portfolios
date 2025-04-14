// Decompiled with JetBrains decompiler
// Type: Player_Gun
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using TMPro;
using UnityEngine;

#nullable disable
public class Player_Gun : MonoBehaviour
{
  [SerializeField]
  private GameObject bulletPrefab;
  [SerializeField]
  private float shotDelayTime = 0.3f;
  public TextMeshProUGUI UpgradeMsg;
  private float firstUpgradeDelayTime = 60f;
  private float SecondUpgradeDelayTime = 120f;
  [SerializeField]
  private float firstCurrentTime;
  [SerializeField]
  private float secondCurrenTime;
  private int upgradeClass = 1;
  public Transform shotPos;
  public Transform shotPos2;
  public Transform shotPos3;
  private AudioSource shotAudio;

  private void Start()
  {
    this.shotAudio = this.GetComponent<AudioSource>();
    this.StartCoroutine("Fire");
  }

  private void Update()
  {
    this.firstCurrentTime += Time.deltaTime;
    this.secondCurrenTime += Time.deltaTime;
    this.FirstUpgrade();
    this.SecondUpgrade();
    this.UpgradeMsg.text = "UPGRADE : " + this.upgradeClass.ToString();
  }

  private IEnumerator Fire()
  {
    while (true)
    {
      if (Input.GetMouseButton(0))
      {
        this.shotAudio.Play();
        Object.Instantiate<GameObject>(this.bulletPrefab, this.shotPos.position, Quaternion.identity);
        if (this.upgradeClass == 2)
          Object.Instantiate<GameObject>(this.bulletPrefab, this.shotPos2.position, Quaternion.identity);
        if (this.upgradeClass == 3)
          Object.Instantiate<GameObject>(this.bulletPrefab, this.shotPos3.position, Quaternion.identity);
        yield return (object) new WaitForSeconds(this.shotDelayTime);
      }
      yield return (object) null;
    }
  }

  private void FirstUpgrade()
  {
    if ((double) this.firstCurrentTime <= (double) this.firstUpgradeDelayTime)
      return;
    ++this.upgradeClass;
    this.firstCurrentTime = 0.0f;
    this.firstUpgradeDelayTime = 99999f;
  }

  private void SecondUpgrade()
  {
    if ((double) this.secondCurrenTime <= (double) this.SecondUpgradeDelayTime)
      return;
    ++this.upgradeClass;
    this.secondCurrenTime = 0.0f;
    this.SecondUpgradeDelayTime = 99999f;
  }
}
