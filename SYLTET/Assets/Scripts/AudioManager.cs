using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] AudioClip[] sounds;


    [Header("Attributes")]
    [Range(0f, 2f)]
    public float volume;
    [Range(1f, 5f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;

    [Header ("PitchMinMax")]
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isPitchAllowed)
            {
                source.pitch = Random.Range(pitchMin, pitchMax);
            }
            
            source.PlayOneShot(source.clip = sounds[Random.Range(0, sounds.Length)]);
        }
    }


}
