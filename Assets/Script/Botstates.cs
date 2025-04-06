using UnityEngine;

public class BotAnimationController : MonoBehaviour
{
    public GameObject playerObject;  // Player��Inspector�Ŏw�肷��
    private Playerstates playerScript;
    private Animator animator;

    void Start()
    {
        // Animator�擾�ibot���g�́j
        animator = GetComponent<Animator>();

        // Player�X�N���v�g���擾
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
                animator.Play("chasedG_Clip"); // �����̓A�j���[�V�����̃X�e�[�g���ɍ��킹�āI
            }
        }
    }
}
