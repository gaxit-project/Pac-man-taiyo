using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // 5�b���LoadSampleScene�֐����Ă�
        Invoke("LoadSampleScene", 5f);
    }

    void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
