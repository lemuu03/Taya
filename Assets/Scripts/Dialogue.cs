using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            dialogue.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            dialogue.SetActive(false);
        }
    }
}
