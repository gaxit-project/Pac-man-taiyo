using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction = Vector2.left; // 初期の移動方向
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RD") || other.CompareTag("LD") || other.CompareTag("RU") || other.CompareTag("LU") || other.CompareTag("RUD") || other.CompareTag("LUD") || other.CompareTag("LRU") || other.CompareTag("LRD") || other.CompareTag("Closs"))
        {
            Intersection intersection = other.GetComponent<Intersection>();
            if (intersection != null)
            {
                ChooseDirection(intersection);
                AdjustSpriteDirection();
            }
        }
    }

    void ChooseDirection(Intersection intersection)
    {
        Vector2 botPos = transform.position;
        List<Vector2> possibleDirections = intersection.GetAllowedDirections();

        // 進行方向が許可されていない場合、進行方向を変更
        if (!possibleDirections.Contains(direction))
        {
            possibleDirections.Remove(-direction); // Uターンを避ける

            if (possibleDirections.Count == 0)
            {
                possibleDirections.Add(-direction); // 行き止まりならUターン
            }

            direction = ChooseBestDirection(possibleDirections, botPos);
        }
    }

    Vector2 ChooseBestDirection(List<Vector2> possibleDirections, Vector2 botPos)
    {
        Vector2 playerPos = player.position;
        Vector2 bestDirection = possibleDirections[0];
        float shortestDistance = Vector2.Distance(botPos + bestDirection, playerPos);

        foreach (Vector2 dir in possibleDirections)
        {
            float distance = Vector2.Distance(botPos + dir, playerPos);
            if (distance < shortestDistance)
            {
                bestDirection = dir;
                shortestDistance = distance;
            }
        }

        return bestDirection;
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







//if (other.CompareTag("RD") || other.CompareTag("LD") || other.CompareTag("RU") || other.CompareTag("LU") || other.CompareTag("RUD") || other.CompareTag("LUD") || other.CompareTag("LRU") || other.CompareTag("LRD") || other.CompareTag("Closs"))