using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNewHeartTrig : MonoBehaviour
{
    public HealthSystem healthSystem;

    public AudioSource heartAudioSource;
    public AudioClip[] heartSounds;

    private void OnCollisionEnter(Collision col)

    {
        if (col.gameObject.CompareTag("Player"))
        {
            AudioClip clip = heartSounds[Random.Range(0, heartSounds.Length)];
            heartAudioSource.PlayOneShot(clip);


            healthSystem.GetHeart();
            Destroy(gameObject);
        }
    }


}
