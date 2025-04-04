using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botrandom : MonoBehaviour
{
    private bool rdy = false;
    public float speed = 3f;
    private Vector2 direction = Vector2.left; // �����̈ړ�����


    private void Start()
    {
        
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
                ChooseRandomDirection(intersection);
                AdjustSpriteDirection();
            }
        }
    }

    void ChooseRandomDirection(Intersection intersection)
    {
        List<Vector2> possibleDirections = intersection.GetAllowedDirections();

        // �i�s������������Ă��Ȃ��ꍇ�A�ύX����
        if (!possibleDirections.Contains(direction))
        {
            possibleDirections.Remove(-direction); // U�^�[���������

            if (possibleDirections.Count == 0)
            {
                possibleDirections.Add(-direction); // �s���~�܂�Ȃ�U�^�[��
            }

            direction = possibleDirections[Random.Range(0, possibleDirections.Count)];
        }
    }

    void AdjustSpriteDirection()
    {
        if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(-1, 1, 1); // �E�����i���]�j
        }
        else if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(1, 1, 1); // �������i�ʏ�j
        }
    }
}
