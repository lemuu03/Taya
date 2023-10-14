using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    [SerializeField] AudioClip keyPickupSFX;
    [SerializeField] GameObject door;


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            // FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            // AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            FindObjectOfType<PlayerMovement>().HoldKey(true);
            SoundFXManager.instance.PlaySoundFXClip(keyPickupSFX, transform, 1f); // PLAY SOUNDFX
            Destroy(gameObject);

            FindObjectOfType<DoorBehaviour>().DoorKey(true);
        }
    }
}
