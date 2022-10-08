using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] AudioClip[] walkSounds;
    [SerializeField] AudioClip[] takeDamageSounds;
    [SerializeField] AudioClip[] destroyPlayerSounds;
    [SerializeField] AudioClip[] winSounds;
    [SerializeField] AudioClip jumpsounds;



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

    private void Update()
    {
        iF(KeyCode.W, source.clip = destroyPlayerSounds[Random.Range(0, destroyPlayerSounds.Length)]);



    }






    private void iF(KeyCode key, AudioClip clip)
    {

        if (Input.GetKeyDown(key))  
        {
            if (isPitchAllowed)
            {
                source.pitch = Random.Range(pitchMin, pitchMax);
            }

            source.PlayOneShot(clip);
        }

    }

}
