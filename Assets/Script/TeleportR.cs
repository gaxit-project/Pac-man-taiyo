using UnityEngine;

public class TeleportR : MonoBehaviour
{
    // テレポート先の座標
    public Vector2 teleportPosition = new Vector2(-3.75f, 0.15f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("teleportL"))
        {
            transform.position = teleportPosition;
        }
    }
}