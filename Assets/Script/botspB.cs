using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BotRandomBSpecial : MonoBehaviour
{
    private Collider2D col;
    private BotrandomB botMove;
    public bool isResetting = false;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        botMove = GetComponent<BotrandomB>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundSE.eatghost();
            float state = other.GetComponent<Playerstates>().plstates;
            if (state == 1f && !isResetting)  // パワークッキー状態で、リセット中でない場合
            {
                StartCoroutine(HandleCollision());
            }
        }
    }

    private IEnumerator HandleCollision()
    {
        isResetting = true;
        col.enabled = false;
        botMove.enabled = false;

        // Step 1: x=0, y=0.3 へ1秒で移動
        Vector3 step1 = new Vector3(0f, 0.3f, transform.position.z);
        yield return StartCoroutine(MoveTo(step1, 1f));

        // Step 2: y=1.05 へ1秒で移動
        Vector3 step2 = new Vector3(step1.x, 1.05f, step1.z);
        yield return StartCoroutine(MoveTo(step2, 1f));

        // Step 3: x=1.335 へ1秒で移動
        Vector3 step3 = new Vector3(1.335f, step2.y, step2.z);
        yield return StartCoroutine(MoveTo(step3, 1f));

        // 再開
        botMove.enabled = true;
        botMove.rdyB = 1;
        col.enabled = true;
        isResetting = false;
    }

    private IEnumerator MoveTo(Vector3 target, float duration)
    {
        Vector3 start = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
