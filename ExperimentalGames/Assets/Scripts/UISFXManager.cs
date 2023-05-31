using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISFXManager : MonoBehaviour
{
    public AudioSource UiSounds;

    public AudioClip clickSound;

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            UiSounds.PlayOneShot(clickSound);
        }
    }
}
