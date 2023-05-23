using UnityEngine;

public class AudioLoopController : MonoBehaviour
{
    public AudioClip audioClip;  // Reference to the audio clip

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
