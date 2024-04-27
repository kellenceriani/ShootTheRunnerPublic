using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeSnapshotOne : MonoBehaviour
{
    public AudioMixerSnapshot newSnapshot;
    public float transitionTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        newSnapshot.TransitionTo(transitionTime);

    }
}
