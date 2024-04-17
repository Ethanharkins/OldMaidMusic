using UnityEngine;

public class DrumButton : MonoBehaviour
{
    public AudioClip soundClip; // Assign this clip in the Unity Inspector

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(soundClip);
        SoundManager.Instance.RecordSound(soundClip);
    }
}
