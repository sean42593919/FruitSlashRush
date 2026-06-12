using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip fruitSliceSound;
    public AudioClip bombSound;
    public AudioClip healSound;
    public AudioClip gameOverSound;
    public AudioClip buttonClickSound;
    public AudioClip backgroundMusic;

    private AudioSource bgmSource;
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        bgmSource = gameObject.AddComponent<AudioSource>();

        bgmSource.clip = backgroundMusic;
        bgmSource.loop = true;
        bgmSource.volume = 0.2f;
        bgmSource.Play();
    }

    public void PlayFruitSlice()
    {
        audioSource.PlayOneShot(fruitSliceSound,0.5f);
    }

    public void PlayBomb()
    {
        audioSource.PlayOneShot(bombSound);
    }

    public void PlayHeal()
    {
        audioSource.PlayOneShot(healSound,0.1f);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
    }

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }
}