using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioClip[] myAudio;
    public void PlayApply()
    {
        GetComponent<AudioSource>().clip = myAudio[1];
        GetComponent<AudioSource>().Play();
    }
    public void PlaySelect()
    {
        GetComponent<AudioSource>().clip = myAudio[0];
        GetComponent<AudioSource>().Play();
    }
    public void PlayBack()
    {
        GetComponent<AudioSource>().clip = myAudio[2];
        GetComponent<AudioSource>().Play();
    }
}
