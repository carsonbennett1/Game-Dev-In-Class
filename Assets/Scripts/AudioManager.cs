using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header ("Audio Sources")]

    public AudioSource sfxSource;
    public AudioSource AmbienceSource;
    public AudioSource rocketSource;

    [Header("Audio Clips")]

    public AudioClip shootClip;
    public AudioClip explosionClip;
    public AudioClip ambientClip;
    public AudioClip rocketClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        PlayAmbientSound();
    }

    public void PlayAmbientSound()
    {
        if (ambientClip != null && AmbienceSource != null)
        {
            AmbienceSource.clip = ambientClip;
            AmbienceSource.loop = true;
            AmbienceSource.Play();
        }
    }

    public void PlaySound (AudioClip clip)
    {
        if (clip !=null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayMovementSound()
    {
        if (rocketSource != null && !rocketSource.isPlaying)
        {
            rocketSource.clip = rocketClip;
            rocketSource.loop = true;
            rocketSource.Play();
        }
    }

    public void StopMovementSound()
    {
        if (rocketSource != null && rocketSource.isPlaying)
        {
            rocketSource.Stop();
        }
    }

}
