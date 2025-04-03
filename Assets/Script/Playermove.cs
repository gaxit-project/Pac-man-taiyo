using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    private bool LR = false;
    private bool UD = false;
    private bool RD = false;
    private bool LD = false;
    private bool RU = false;
    private bool LU = false;
    private bool RUD = false;
    private bool LUD = false;
    private bool LRU = false;
    private bool LRD = false;
    private bool Closs = false;

    public float speed = 5f;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LR"))
        {
            LR = true;
        }
        if (other.CompareTag("UD"))
        {
            UD = true;
        }
        if (other.CompareTag("RD"))
        {
            RD = true;
        }
        if (other.CompareTag("LD"))
        {
            LD = true;
        }
        if (other.CompareTag("RU"))
        {
            RU = true;
        }
        if (other.CompareTag("LU"))
        {
            LU = true;
        }
        if (other.CompareTag("RUD"))
        {
            RUD = true;
        }
        if (other.CompareTag("LUD"))
        {
            LUD = true;
        }
        if (other.CompareTag("LRU"))
        {
            LRU = true;
        }
        if (other.CompareTag("LRD"))
        {
            LRD = true;
        }
        if (other.CompareTag("Closs"))
        {
            Closs = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LR"))
        {
            LR = false;
        }
        if (other.CompareTag("UD"))
        {
            UD = false;
        }
        if (other.CompareTag("RD"))
        {
            RD = false;
        }
        if (other.CompareTag("LD"))
        {
            LD = false;
        }
        if (other.CompareTag("RU"))
        {
            RU = false;
        }
        if (other.CompareTag("LU"))
        {
            LU = false;
        }
        if (other.CompareTag("RUD"))
        {
            RUD = false;
        }
        if (other.CompareTag("LUD"))
        {
            LUD = false;
        }
        if (other.CompareTag("LRU"))
        {
            LRU = false;
        }
        if (other.CompareTag("LRD"))
        {
            LRD = false;
        }
        if (other.CompareTag("Closs"))
        {
            Closs = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.D) && (LR || RD || RU || RUD || LRU || LRD || Closs))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180); // YŽ²‚ð180“x‰ñ“]
        }
        if (Input.GetKeyDown(KeyCode.A) && (LR || LD || LU || LUD || LRU || LRD || Closs))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // YŽ²‚ð180“x‰ñ“]
        }
        if (Input.GetKeyDown(KeyCode.W) && (UD || RU || LU || LUD || RUD || LRU || Closs))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetKeyDown(KeyCode.S) && (UD || RD || LD || LUD || RUD || LRD || Closs))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
            
                
        
