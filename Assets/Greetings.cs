using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greetings : MonoBehaviour
{
    public List<AudioClip> greetings = new List<AudioClip>();

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioClip clip = greetings[Random.Range(0, greetings.Count - 1)];
        source.PlayOneShot(clip);
        Debug.Log("Trigger!");
    }
}
