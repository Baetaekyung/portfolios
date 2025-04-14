// Decompiled with JetBrains decompiler
// Type: MapGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Tilemaps;

#nullable disable
public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector2Int mapSize;
    [SerializeField]
    private float minimumDevideRate;
    [SerializeField]
    private float maximumDivideRate;
    [SerializeField]
    private GameObject line;
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject roomLine;
    [SerializeField]
    private int maximumDepth;
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private RuleTile roomTile;
    [SerializeField]
    private RuleTile wallTile;
    [SerializeField]
    private Tile outTile;
    [SerializeField]
    private RuleTile roadTile;
    [SerializeField]
    private GameObject player;
    private int lastRoomInfo;

    private void Start()
    {
        this.FillBackground();
        Node tree = new Node(new RectInt(0, 0, this.mapSize.x, this.mapSize.y));
        this.Divide(tree, 0);
        this.GenerateRoom(tree, 0);
        this.GenerateLoad(tree, 0);
        this.FillWall();
    }

    private void Divide(Node tree, int n)
    {
        if (n == this.maximumDepth)
            return;
        int num1 = Mathf.Max(tree.nodeRect.width, tree.nodeRect.height);
        int num2 = Mathf.RoundToInt(Random.Range((float)num1 * this.minimumDevideRate, (float)num1 * this.maximumDivideRate));
        if (tree.nodeRect.width >= tree.nodeRect.height)
        {
            tree.leftNode = new Node(new RectInt(tree.nodeRect.x, tree.nodeRect.y, num2, tree.nodeRect.height));
            tree.rightNode = new Node(new RectInt(tree.nodeRect.x + num2, tree.nodeRect.y, tree.nodeRect.width - num2, tree.nodeRect.height));
        }
        else
        {
            tree.leftNode = new Node(new RectInt(tree.nodeRect.x, tree.nodeRect.y, tree.nodeRect.width, num2));
            tree.rightNode = new Node(new RectInt(tree.nodeRect.x, tree.nodeRect.y + num2, tree.nodeRect.width, tree.nodeRect.height - num2));
        }
        tree.leftNode.parNode = tree;
        tree.rightNode.parNode = tree;
        this.Divide(tree.leftNode, n + 1);
        this.Divide(tree.rightNode, n + 1);
    }

    private RectInt GenerateRoom(Node tree, int n)
    {
        RectInt rect;
        if (n == this.maximumDepth)
        {
            rect = tree.nodeRect;
            int width = Random.Range(rect.width / 2, rect.width - 1);
            int height = Random.Range(rect.height / 2, rect.height - 1);
            rect = new RectInt(rect.x + Random.Range(1, rect.width - width), rect.y + Random.Range(1, rect.height - height), width, height);
            this.FillRoom(rect);
        }
        else
        {
            tree.leftNode.roomRect = this.GenerateRoom(tree.leftNode, n + 1);
            tree.rightNode.roomRect = this.GenerateRoom(tree.rightNode, n + 1);
            rect = tree.leftNode.roomRect;
        }
        return rect;
    }

    private void GenerateLoad(Node tree, int n)
    {
        if (n == this.maximumDepth)
            return;
        Vector2Int center1 = tree.leftNode.Center;
        Vector2Int center2 = tree.rightNode.Center;
        for (int index = Mathf.Min(center1.x, center2.x); index <= Mathf.Max(center1.x, center2.x); ++index)
            this.tileMap.SetTile(new Vector3Int(index - this.mapSize.x / 2, center1.y - this.mapSize.y / 2, 0), (TileBase)this.roadTile);
        for (int index = Mathf.Min(center1.y, center2.y); index <= Mathf.Max(center1.y, center2.y); ++index)
            this.tileMap.SetTile(new Vector3Int(center2.x - this.mapSize.x / 2, index - this.mapSize.y / 2, 0), (TileBase)this.roadTile);
        this.GenerateLoad(tree.leftNode, n + 1);
        this.GenerateLoad(tree.rightNode, n + 1);
    }

    private void FillBackground()
    {
        for (int index1 = -10; index1 < this.mapSize.x + 10; ++index1)
        {
            for (int index2 = -10; index2 < this.mapSize.y + 10; ++index2)
                this.tileMap.SetTile(new Vector3Int(index1 - this.mapSize.x / 2, index2 - this.mapSize.y / 2, 0), (TileBase)this.outTile);
        }
    }

    private void FillWall()
    {
        for (int index1 = 0; index1 < this.mapSize.x; ++index1)
        {
            for (int index2 = 0; index2 < this.mapSize.y; ++index2)
            {
                if ((Object)this.tileMap.GetTile(new Vector3Int(index1 - this.mapSize.x / 2, index2 - this.mapSize.y / 2, 0)) == (Object)this.outTile)
                {
                    for (int index3 = -1; index3 <= 1; ++index3)
                    {
                        for (int index4 = -1; index4 <= 1; ++index4)
                        {
                            if ((index3 != 0 || index4 != 0) && (Object)this.tileMap.GetTile(new Vector3Int(index1 - this.mapSize.x / 2 + index3, index2 - this.mapSize.y / 2 + index4, 0)) == (Object)this.roomTile)
                            {
                                this.tileMap.SetTile(new Vector3Int(index1 - this.mapSize.x / 2, index2 - this.mapSize.y / 2, 0), (TileBase)this.wallTile);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    private void FillRoom(RectInt rect)
    {
        ++this.lastRoomInfo;
        for (int x = rect.x; x < rect.x + rect.width; ++x)
        {
            for (int y = rect.y; y < rect.y + rect.height; ++y)
            {
                this.tileMap.SetTile(new Vector3Int(x - this.mapSize.x / 2, y - this.mapSize.y / 2, 0), (TileBase)this.roomTile);
                this.player.transform.position = (Vector3)new Vector3Int(x - this.mapSize.x / 2, y - this.mapSize.y / 2, 0);
                if (this.lastRoomInfo != 16)
                    Singleton<EnemyGenerator>.Instance.EnemySpawn(new Vector3((float)(x - this.mapSize.x / 2 + 1), (float)(y - this.mapSize.y / 2 + 1), 0.0f));
            }
        }
    }
}
