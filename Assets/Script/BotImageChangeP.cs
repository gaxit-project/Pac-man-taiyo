using UnityEngine;

public class BotImageChangeP : MonoBehaviour
{
    public Animator animator;  // Bot�I�u�W�F�N�g��Animator
    public Playerstates playerScript;  // PlayerScript�ւ̎Q��
    public eatenbot eatenbot;

    // Animator�̃p�����[�^�[��
    private static readonly int IsPoweredUp = Animator.StringToHash("IsPoweredUp");
    private static readonly int IsEaten = Animator.StringToHash("IsEaten");

    void Start()
    {
        // Animator���ݒ肳��Ă��邩�m�F
        if (animator == null)
        {
            animator = GetComponent<Animator>();  // Animator���擾
        }
    }

    void Update()
    {
        // PlayerScript��plstates��1�̎��A�A�j���[�V�����p�����[�^��؂�ւ�
        if (playerScript.plstates == 1)
        {
            animator.SetBool(IsPoweredUp, true);  // �p���[�A�b�v��ԂɕύX
        }
        else
        {
            animator.SetBool(IsPoweredUp, false);  // �ʏ��Ԃɖ߂�
        }
    }
}
