using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotrandomP : MonoBehaviour
{
    public float rdyP = 0;
    public float targetY = 1.05f;
    public float duration = 1f;
    public float speed = 3f;
    private Vector2 direction = Vector2.left; // 初期の移動方向

    void Start()
    {
        StartCoroutine(MoveToY());
    }

    IEnumerator MoveToY()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x, targetY, startPos.z);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        rdyP = 1;
    }

    void Update()
    {
        if (rdyP == 1)
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
