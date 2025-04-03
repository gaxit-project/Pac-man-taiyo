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
        UpdateRotation(); // �����̌�����ݒ�
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RD")|| other.CompareTag("LD") || other.CompareTag("RU") || other.CompareTag("LU") || other.CompareTag("RUD") || other.CompareTag("LUD") || other.CompareTag("LRU") || other.CompareTag("LRD") || other.CompareTag("Closs")) // �����_�Ȃ����������
        {
            ChooseDirection();
            UpdateRotation(); // �V���������ɉ�]
        }
    }

    void ChooseDirection()
    {
        Vector2 playerPos = player.position;
        Vector2 botPos = transform.position;

        // �i�߂�������擾
        List<Vector2> possibleDirections = new List<Vector2>();

        if (CanMove(Vector2.up)) possibleDirections.Add(Vector2.up);
        if (CanMove(Vector2.down)) possibleDirections.Add(Vector2.down);
        if (CanMove(Vector2.left)) possibleDirections.Add(Vector2.left);
        if (CanMove(Vector2.right)) possibleDirections.Add(Vector2.right);

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

    bool CanMove(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f);
        return (hit.collider != null && (hit.collider.CompareTag("LR") || (hit.collider.CompareTag("UD")))); // "Path"�^�O���������Ȃ�i�߂�
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