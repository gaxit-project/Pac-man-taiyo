using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerstates : MonoBehaviour
{
    public float plstates = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powercookie"))
        {
            plstates = 1;
            StartCoroutine(playerstates(5f));
        }
        if (other.CompareTag("enemy"))
        {
            if(plstates == 0)
            {
                SceneManager.LoadScene("gameover");
            }
        }
    }

    IEnumerator playerstates(float delay)
    {
        plstates = 1;
        yield return new WaitForSeconds(delay);
        plstates = 0;
    }
}
