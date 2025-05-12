using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // 5•bŒã‚ÉLoadSampleSceneŠÖ”‚ğŒÄ‚Ô
        Invoke("LoadSampleScene", 5f);
    }

    void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
