using System.Collections;
using UnityEngine;

public class eatenbot : MonoBehaviour
{
    private CircleCollider2D col;
    public bool isMoving = false;
    public bool isReturn = false;
    public Playerstates playerScript;

    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            Playerstates playerScript = other.GetComponent<Playerstates>();
            if (playerScript != null && playerScript.plstates == 1f)
            {
                StartCoroutine(MoveAndDisableCollision());
            }
        }
    }

    IEnumerator MoveAndDisableCollision()
    {
        isMoving = true;
        isReturn = true;

        // 当たり判定を無効にする
        col.enabled = false;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(0f, 0.3f, startPos.z);

        float duration = 2f;
        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

         col.enabled = true;

        isMoving = false;
    }
}
