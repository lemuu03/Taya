using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] AudioClip healthSFX;


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddLife(1);
            SoundFXManager.instance.PlaySoundFXClip(healthSFX, transform, 1f); // PLAY SOUNDFX
            Destroy(gameObject);
        }
    }
}
