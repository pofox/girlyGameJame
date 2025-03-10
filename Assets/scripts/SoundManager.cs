using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource shootingSound;
    [SerializeField] private AudioSource enemyShootingSound;
    [SerializeField] private AudioSource backgroundMusic;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip pickUpClip;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float masterVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;
    [Range(0f, 1f)] public float musicVolume = 1f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayPickUpSound()
    {
        if (shootingSound != null && pickUpClip != null)
        {
            shootingSound.volume = sfxVolume * masterVolume;
            shootingSound.pitch = Random.Range(0.8f, 1.2f);
            shootingSound.PlayOneShot(pickUpClip);
        }
        else
        {
            Debug.LogError("Shooting sound or clip not assigned.");
        }
    }

    public void PlayenemyShootingSound()
    {
        if (enemyShootingSound != null)
        {
            enemyShootingSound.volume = sfxVolume * masterVolume;
            enemyShootingSound.pitch = Random.Range(0.8f, 1.2f);
            enemyShootingSound.Play();
        }
        else
        {
            Debug.LogError("Reload sound not assigned.");
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.volume = musicVolume * masterVolume;
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }

    public void muteSFX()
    {
        if (sfxVolume == 0)
        {
            sfxVolume = 1;
        }
        else
        {
            sfxVolume = 0;
        }
        UpdateVolumes();
    }

    public void muteMusic()
    {
        if (musicVolume == 0)
        {
            musicVolume = 1;
        }
        else
        {
            musicVolume = 0;
        }
        UpdateVolumes();
    }

    public void UpdateVolumes()
    {
        if (shootingSound != null)
            shootingSound.volume = sfxVolume * masterVolume;

        if (backgroundMusic != null)
            backgroundMusic.volume = musicVolume * masterVolume;

        if (enemyShootingSound != null)
            enemyShootingSound.volume = sfxVolume * masterVolume;
    }
}