using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] AudioClip powerUpPickupSFX;

    // [SerializeField] float timerValue = 3f;
    public bool timeUp;
    

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            // FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            // AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            FindObjectOfType<PlayerMovement>().powerUp(true);
            SoundFXManager.instance.PlaySoundFXClip(powerUpPickupSFX, transform, 1f); // PLAY SOUNDFX
            Destroy(gameObject);
        }
    }
}
