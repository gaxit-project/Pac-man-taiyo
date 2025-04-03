using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction = Vector2.left; // 初期の移動方向
    private Vector2 previousDirection = Vector2.zero; // 直前の移動方向
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateRotation();
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
                UpdateRotation();
            }
        }
    }

    void ChooseDirection(Intersection intersection)
    {
        Vector2 playerPos = player.position;
        Vector2 botPos = transform.position;

        // 進める方向を交差点の情報から取得
        List<Vector2> possibleDirections = intersection.GetAllowedDirections();

        // Uターンを防ぐ
        possibleDirections.Remove(-previousDirection);

        // プレイヤーに最も近づく方向を選択
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

        // 方向を変更
        previousDirection = direction;
        direction = bestDirection;
    }

    void UpdateRotation()
    {
        if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (direction == Vector2.right)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (direction == Vector2.up)
            transform.rotation = Quaternion.Euler(0, 0, -90);
        else if (direction == Vector2.down)
            transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
