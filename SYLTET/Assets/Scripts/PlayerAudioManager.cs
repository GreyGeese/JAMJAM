using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    private AudioSource source;
    
    [SerializeField] AudioClip[] takeDamageSounds;
    [SerializeField] AudioClip[] destroyPlayerSounds;
    [SerializeField] AudioClip[] jamSplatteronFX;   // with delay or put on the fx instead
    [SerializeField] AudioClip[] winSounds;
    [SerializeField] AudioClip jumpsound;
    [SerializeField] AudioClip walksound;
    [SerializeField] AudioClip runsound;



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
        playSoundswithKeyCode(KeyCode.Y, source.clip = destroyPlayerSounds[Random.Range(0, destroyPlayerSounds.Length)]);
        playSoundswithKeyCode(KeyCode.U, source.clip = jamSplatteronFX[Random.Range(0, jamSplatteronFX.Length)]);
        playSoundswithKeyCode(KeyCode.I, source.clip = takeDamageSounds[Random.Range(0, takeDamageSounds.Length)]);
        playSoundswithKeyCode(KeyCode.O, source.clip = winSounds[Random.Range(0, winSounds.Length)]);
        playSoundswithKeyCode(KeyCode.H, source.clip = walksound);
        playSoundswithKeyCode(KeyCode.J, source.clip = runsound);
        playSoundswithKeyCode(KeyCode.K, source.clip = jumpsound);



    }






    private void playSoundswithKeyCode(KeyCode key, AudioClip clip)
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
