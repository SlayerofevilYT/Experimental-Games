using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;       // Audio clip to play
    private AudioSource audioSource;  // Reference to the AudioSource component

    public float minInterval = 7f;   // Minimum interval between audio plays
    public float maxInterval = 15f;   // Maximum interval between audio plays

    private float nextPlayTime;       // Time when the next audio play should occur

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        CalculateNextPlayTime();
    }

    private void Update()
    {
        if (Time.time >= nextPlayTime)
        {
            PlayRandomAudio();
            CalculateNextPlayTime();
        }
    }

    private void PlayRandomAudio()
    {
        if (audioClip == null)
        {
            Debug.LogWarning("No audio clip assigned to the RandomAudioPlayer.");
            return;
        }

        audioSource.PlayOneShot(audioClip);
    }

    private void CalculateNextPlayTime()
    {
        float interval = Random.Range(minInterval, maxInterval);
        nextPlayTime = Time.time + interval;
    }
}
