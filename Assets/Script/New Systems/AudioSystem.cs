using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : IGameSystemMono
{
    public override void DestoryGameSystem() { }
    public override void StartGameSystem() { }
    public AudioClip select,apply,back;
    public AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = gameObject.AddComponent<AudioSource>();
    }
    public void PlayApply()
    {
        audioPlayer.clip = apply;
        audioPlayer.Play();
    }
    public void PlaySelect()
    {
        audioPlayer.clip = select;
        audioPlayer.Play();
    }
    public void PlayBack()
    {
        audioPlayer.clip = back;
        audioPlayer.Play();
    }
}
