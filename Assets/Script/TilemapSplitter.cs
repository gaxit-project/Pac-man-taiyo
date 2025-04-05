using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSplitter : MonoBehaviour
{
    [Header("分割したいタイルマップ")]
    public Tilemap targetTilemap; // 🔸分割対象のタイルマップを指定

    [Header("生成するプレハブ（スプライト+コライダー）")]
    public GameObject tilePrefab; // 🔸分割して生成するプレハブ（SpriteRenderer + Collider付き）

    void Start()
    {
        if (targetTilemap == null)
        {
            Debug.LogError("Tilemap が指定されていません！");
            return;
        }

        if (tilePrefab == null)
        {
            Debug.LogError("TilePrefab が指定されていません！");
            return;
        }

        SplitTilemap();
    }

    void SplitTilemap()
    {
        BoundsInt bounds = targetTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);

                // この tilemap にタイルがあるか確認
                if (targetTilemap.HasTile(cellPos))
                {
                    // タイルのワールド座標を取得
                    Vector3 worldPos = targetTilemap.GetCellCenterWorld(cellPos);

                    // タイルのプレハブを生成
                    GameObject newTile = Instantiate(tilePrefab, worldPos, Quaternion.identity);
                    newTile.name = "Tile_" + x + "_" + y;
                    newTile.transform.parent = this.transform; // 整理しやすく親に設定
                }
            }
        }

        // 元の Tilemap のタイルを削除
        targetTilemap.ClearAllTiles();
    }
}
