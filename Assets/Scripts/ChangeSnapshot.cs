using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeSnapshot : MonoBehaviour
{
    public AudioMixerSnapshot newSnapshot;
    public AudioMixerSnapshot defaultSnapshot;
    public float transitionTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        newSnapshot.TransitionTo(transitionTime);
    }

    private void OnTriggerExit(Collider other)
    {
        defaultSnapshot.TransitionTo(transitionTime);
    }
}
