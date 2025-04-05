using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    IEnumerator playerstates(float delay)
    {
        plstates = 1;
        yield return new WaitForSeconds(delay);
        plstates = 0;
    }

}
