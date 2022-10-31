using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    [SerializeField] private AudioClip[] clips = new AudioClip[0];
    [SerializeField] private RangedFloat volume = new RangedFloat(1, 1);

    [MinMaxRange(0f, 2f)]
    [SerializeField] private RangedFloat pitch = new RangedFloat(1, 1);

    [MinMaxRange(0f, 1000f)]
    [SerializeField] private RangedFloat distance = new RangedFloat(1, 1000);

    [SerializeField] private AudioMixerGroup mixer;

    public void Play(AudioSource source)
    {
        source.outputAudioMixerGroup = mixer;

        int clipIndex = UnityEngine.Random.Range(0, clips.Length);
        source.clip = clips[clipIndex];

        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.volume = Random.Range(volume.minValue, volume.maxValue);

        source.minDistance = distance.minValue;
        source.maxDistance = distance.maxValue;

        source.Play();
    }
}