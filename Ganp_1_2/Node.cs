// Decompiled with JetBrains decompiler
// Type: Node
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Node
{
  public Node leftNode;
  public Node rightNode;
  public Node parNode;
  public RectInt nodeRect;
  public RectInt roomRect;

  public Vector2Int Center
  {
    get
    {
      return new Vector2Int(this.roomRect.x + this.roomRect.width / 2, this.roomRect.y + this.roomRect.height / 2);
    }
  }

  public Node(RectInt rect) => this.nodeRect = rect;
}
