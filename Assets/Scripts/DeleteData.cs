using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeleteData : MonoBehaviour
{
    public static void DeletePLayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Successfully Deleted");
    }
}
