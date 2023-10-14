using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float platformSpeed;
    [SerializeField] int startingPoint;
    [SerializeField] Transform[] points;
    
    private int i; // index of the array
    void Start()
    {
        transform.position = points[startingPoint].position;        
    }

    void Update()
    {
        // checking the distance of the platform and the point

        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length) // check if the platform was on the last point after the index increase
            {
                i = 0; // reset the index
            }
        }

        // moving the platform to the point position with the index 'i'
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, platformSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
