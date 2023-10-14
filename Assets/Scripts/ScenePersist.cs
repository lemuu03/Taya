using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake() //first to run in unity, faster than start
    {
        
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length; //create an array cuz it finds all the things
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }

}
