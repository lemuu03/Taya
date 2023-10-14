using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] float openPosValueX = 3f;
    [SerializeField] float openPosValueY = 3f;
    bool isDoorOpen;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    float doorSpeed = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x + openPosValueX, transform.position.y + openPosValueY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoorOpen)
        {
            OpenDoor();
        }
        else if (!isDoorOpen)
        {
            CloseDoor();
        }
    }

    public void DoorKey(bool key)
    {
        isDoorOpen = key;
    }

    void OpenDoor()
    {
        if(transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorSpeed * Time.deltaTime);
        }
    }

    void CloseDoor()
    {
        if(transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, doorSpeed * Time.deltaTime);
        }
    }
}
