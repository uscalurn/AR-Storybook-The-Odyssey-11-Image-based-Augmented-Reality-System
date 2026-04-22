using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRunSound : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> footstepSounds;
    
    // Hàm gọi từ animation event (gắn vào bước chân)
    public void PlayFootstepSound()
    {
        if (footstepSounds.Count == 0 || audioSource == null) return;

        AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Count)];
        audioSource.PlayOneShot(clip);
    }
}
