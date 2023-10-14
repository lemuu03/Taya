using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject fallingObj;
    [SerializeField] Transform fallingPoint;
     // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("LaunchObject", 1f, Random.Range(1f, 5f));
    }

    void LaunchObject()
    {
        Instantiate(fallingObj, fallingPoint.position, transform.rotation);
    }
}
