using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootstepManager : MonoBehaviour
{
    public List<AudioClip> planeSteps = new List<AudioClip>();

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayStep()
    {
        AudioClip clip = planeSteps[Random.Range(0, planeSteps.Count)];
        source.PlayOneShot(clip);
    }
}