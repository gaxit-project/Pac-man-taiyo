using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotrandomY : MonoBehaviour
{
    private float rdyY = 0;
    public float speed = 1.5f;
    private Vector2 direction = Vector2.left; // 初期の移動方向


    private void Start()
    {
        StartCoroutine(MoveSequence());
    }

    IEnumerator MoveSequence()
    {
        // 1. y=0 <-> y=0.3 を13秒間ループ
        float elapsed = 0f;
        bool goingUp = true;
        while (elapsed < 28f)
        {
            float t = 0f;
            Vector3 start = transform.position;
            Vector3 end = new Vector3(start.x, goingUp ? 0.3f : 0f, start.z);

            while (t < 1f && elapsed < 13f)
            {
                transform.position = Vector3.Lerp(start, end, t);
                t += Time.deltaTime;
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = end;
            goingUp = !goingUp;
        }

        // 2. xを0に1秒で移動
        Vector3 xStart = transform.position;
        Vector3 xEnd = new Vector3(0f, xStart.y, xStart.z);
        float tX = 0f;
        while (tX < 1f)
        {
            transform.position = Vector3.Lerp(xStart, xEnd, tX);
            tX += Time.deltaTime;
            yield return null;
        }
        transform.position = xEnd;

        // 3. yを1.05に1秒で移動
        Vector3 yStart = transform.position;
        Vector3 yEnd = new Vector3(yStart.x, 1.05f, yStart.z);
        float tY = 0f;
        while (tY < 1f)
        {
            transform.position = Vector3.Lerp(yStart, yEnd, tY);
            tY += Time.deltaTime;
            yield return null;
        }
        transform.position = yEnd;
        rdyY = 1;
    }

    void Update()
    {
        if(rdyY == 1)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RD") || other.CompareTag("LD") || other.CompareTag("RU") || other.CompareTag("LU") || other.CompareTag("RUD") || other.CompareTag("LUD") || other.CompareTag("LRU") || other.CompareTag("LRD") || other.CompareTag("Closs"))
        {
            Intersection intersection = other.GetComponent<Intersection>();
            if (intersection != null)
            {
                ChooseRandomDirection(intersection);
                AdjustSpriteDirection();
            }
        }
    }

    void ChooseRandomDirection(Intersection intersection)
    {
        List<Vector2> possibleDirections = intersection.GetAllowedDirections();

        // 進行方向が許可されていない場合、変更する
        if (!possibleDirections.Contains(direction))
        {
            possibleDirections.Remove(-direction); // Uターンを避ける

            if (possibleDirections.Count == 0)
            {
                possibleDirections.Add(-direction); // 行き止まりならUターン
            }

            direction = possibleDirections[Random.Range(0, possibleDirections.Count)];
        }
    }

    void AdjustSpriteDirection()
    {
        if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 右向き（反転）
        }
        else if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(1, 1, 1); // 左向き（通常）
        }
    }
}
