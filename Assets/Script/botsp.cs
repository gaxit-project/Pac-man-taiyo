using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BotSpecialBehavior : MonoBehaviour
{
    private Collider2D col;
    private BotMove botMove;
    private Transform player;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        botMove = GetComponent<BotMove>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundSE.eatghost();
            float state = other.GetComponent<Playerstates>().plstates;
            if (state == 1f)
            {
                StartCoroutine(HandleCollision());
            }
        }
    }

    private IEnumerator HandleCollision()
    {
        col.enabled = false;
        botMove.enabled = false;

        Vector3 startPos = transform.position;

        // 1. 2•b‚Å y=0.3 ‚ÉˆÚ“®
        Vector3 step1 = new Vector3(0f, 0.3f, startPos.z);
        yield return StartCoroutine(MoveToPosition(step1, 2f));

        // 2. 1•b‚Å y=1.05 ‚ÉˆÚ“®ix‚Í‚»‚Ì‚Ü‚Üj
        Vector3 step2 = new Vector3(step1.x, 1.05f, step1.z);
        yield return StartCoroutine(MoveToPosition(step2, 1f));

        // 3. 1•b‚Å x=1.335 ‚ÉˆÚ“®iy‚Í‚»‚Ì‚Ü‚Üj
        Vector3 step3 = new Vector3(1.335f, step2.y, step2.z);
        yield return StartCoroutine(MoveToPosition(step3, 1f));

        // 4. BotMoveÄŠJ
        botMove.direction = Vector2.down; // ‚Ü‚½‚Í”CˆÓ‚Ì‰Šú•ûŒü
        botMove.enabled = true;
        yield return null;
        botMove.ForceDirectionCheck();
        col.enabled = true;
    }

    private IEnumerator MoveToPosition(Vector3 target, float duration)
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
