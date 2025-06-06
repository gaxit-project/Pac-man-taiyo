using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // 5秒後にLoadSampleScene関数を呼ぶ
        Invoke("LoadSampleScene", 5f);
    }

    void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
