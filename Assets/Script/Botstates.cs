using UnityEngine;

public class BotAnimationController : MonoBehaviour
{
    public GameObject playerObject;  // PlayerをInspectorで指定する
    private Playerstates playerScript;
    private Animator animator;

    void Start()
    {
        // Animator取得（bot自身の）
        animator = GetComponent<Animator>();

        // Playerスクリプトを取得
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<Playerstates>();
        }
    }

    void Update()
    {
        if (playerScript != null && animator != null)
        {
            if (playerScript.plstates == 1f)
            {
                animator.Play("chasedG_Clip"); // ここはアニメーションのステート名に合わせて！
            }
        }
    }
}
