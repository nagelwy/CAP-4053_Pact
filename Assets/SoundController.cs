using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] clips;
    public void PlaySound(int index)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(clips[index]);
    }
}
