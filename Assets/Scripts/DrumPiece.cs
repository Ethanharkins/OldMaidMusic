using UnityEngine;

public class DrumPiece : MonoBehaviour
{
    private AudioSource audioSource;  // This should declare the variable within the class scope

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject: " + gameObject.name);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Drum clicked!");
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Failed to find AudioSource on: " + gameObject.name);
        }
    }
}

