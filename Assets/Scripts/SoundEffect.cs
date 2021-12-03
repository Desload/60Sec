using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : Singleton<SoundEffect>
{
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private AudioSource player;
    public void AudioPlay()
    {
        Debug.Log(12);
        player.Stop();
        var value = Random.Range(0, footSteps.Length);
        player.clip = footSteps[value];
        player.Play();
    }
}
