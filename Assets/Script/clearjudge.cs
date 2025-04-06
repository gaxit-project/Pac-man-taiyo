using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCookies : MonoBehaviour
{
    // 毎フレーム確認する
    void Update()
    {
        // cookieタグとpowercookieタグのオブジェクトを探す
        GameObject[] cookies = GameObject.FindGameObjectsWithTag("cookie");
        GameObject[] powerCookies = GameObject.FindGameObjectsWithTag("Powercookie");

        // 両方の配列が空なら（=全て回収されたなら）クリアシーンに移動
        if (cookies.Length == 0 && powerCookies.Length == 0)
        {
            SceneManager.LoadScene("clear");
        }
    }
}
