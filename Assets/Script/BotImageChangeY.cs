using UnityEngine;

public class BotImageChangeY : MonoBehaviour
{
    public Animator animator;  // BotオブジェクトのAnimator
    public Playerstates playerScript;  // PlayerScriptへの参照
    public BotRandomYSpecial BotspY;

    // Animatorのパラメーター名
    private static readonly int IsPoweredUp = Animator.StringToHash("IsPoweredUp");
    private static readonly int IsEaten = Animator.StringToHash("IsEaten");

    void Start()
    {
        // Animatorが設定されているか確認
        if (animator == null)
        {
            animator = GetComponent<Animator>();  // Animatorを取得
        }
    }

    void Update()
    {
        // PlayerScriptのplstatesが1の時、アニメーションパラメータを切り替え
        if (playerScript.plstates == 1)
        {
            animator.SetBool(IsPoweredUp, true);  // パワーアップ状態に変更
        }
        else
        {
            animator.SetBool(IsPoweredUp, false);  // 通常状態に戻す
        }
        if (BotspY.isResetting == true)
        {
            animator.SetBool(IsEaten, true);  // パワーアップ状態に変更
        }
        else
        {
            animator.SetBool(IsEaten, false);  // 通常状態に戻す
        }
    }
}
