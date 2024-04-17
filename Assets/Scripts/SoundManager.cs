using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private List<AudioSource> loopLayers = new List<AudioSource>();
    private List<AudioClip> currentRecording = new List<AudioClip>();
    private List<float> currentTimings = new List<float>();
    private bool isRecording = false;
    private float startTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleRecording()
    {
        isRecording = !isRecording;
        if (isRecording)
        {
            currentRecording.Clear();
            currentTimings.Clear();
            startTime = Time.time;
        }
        else
        {
            StartCoroutine(PlayRecording(currentRecording, currentTimings));
        }
    }

    public void RecordSound(AudioClip clip)
    {
        if (isRecording)
        {
            currentRecording.Add(clip);
            currentTimings.Add(Time.time - startTime);
            startTime = Time.time;
        }
    }

    IEnumerator PlayRecording(List<AudioClip> clips, List<float> timings)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        loopLayers.Add(source);
        while (true)
        {
            for (int i = 0; i < clips.Count; i++)
            {
                source.clip = clips[i];
                source.Play();
                yield return new WaitForSeconds(timings[i]);
            }
        }
    }

    public void StopAllLoops()
    {
        foreach (var source in loopLayers)
        {
            if (source != null)
            {
                Destroy(source);
            }
        }
        loopLayers.Clear();
    }
}
