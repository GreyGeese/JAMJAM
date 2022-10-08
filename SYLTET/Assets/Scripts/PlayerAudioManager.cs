using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] AudioClip[] takeDamageSounds;
    [SerializeField] AudioClip[] destroyPlayerSounds;
    [SerializeField] AudioClip[] jamSplatteronFX;   // with delay or put on the fx instead
    [SerializeField] AudioClip[] shootSounds;
    [SerializeField] AudioClip[] winSounds;
    [SerializeField] AudioClip jumpsound;
    [SerializeField] AudioClip walksound;
    [SerializeField] AudioClip runsound;

    private AudioClip clip;

    [Header("Attributes")]
    [Range(0f, 2f)]
    public float volume;
    [Range(1f, 5f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;

    [Header("PitchMinMax")]
    [SerializeField] bool isPitchAllowed;
    [Range(1f, 5f)]
    public float pitchMin;
    [Range(1f, 5f)]
    public float pitchMax;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.pitch = pitch;
        source.volume = volume;
        source.spatialBlend = spatialBlend;


    }

    public void playSoundswithKeyCode(string inputSound)
    {

        if (inputSound == "destroyPlayer")
        {
            clip = destroyPlayerSounds[Random.Range(0, destroyPlayerSounds.Length)];
        }
        if (inputSound == "weehoo")
        {
            clip = takeDamageSounds[Random.Range(0, takeDamageSounds.Length)];
        }
        if (inputSound == "winSound")
        {
            clip = winSounds[Random.Range(0, winSounds.Length)];
        }
        if (inputSound == "jumpSound")
        {
            clip = jumpsound;
        }
        if (inputSound == "shoot")
        {
            clip = shootSounds[Random.Range(0, shootSounds.Length)];
        }


        if (isPitchAllowed)
        {
            source.pitch = Random.Range(pitchMin, pitchMax);
        }

        source.PlayOneShot(clip);
    }
    public void RunSound()
    {
        source.PlayOneShot(runsound);
    }
    public void JamEffectSounds()
    {
        source.PlayOneShot(jamSplatteronFX[Random.Range(0, jamSplatteronFX.Length)]);
    }

}   




    





