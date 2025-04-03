using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction = Vector2.left; // �����̈ړ�����
    private Vector2 previousDirection = Vector2.zero; // ���O�̈ړ�����
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

        // �i�߂�����������_�̏�񂩂�擾
        List<Vector2> possibleDirections = intersection.GetAllowedDirections();

        // U�^�[����h��
        possibleDirections.Remove(-previousDirection);

        // �v���C���[�ɍł��߂Â�������I��
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

        // ������ύX
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
