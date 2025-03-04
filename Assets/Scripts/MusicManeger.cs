using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource; // Chỉ cần 1 AudioSource để phát tất cả âm thanh
    public AudioClip placeSound;
    public AudioClip winSound;
    public AudioClip drawSound;
    public AudioClip clickButtonSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại MusicManager khi load scene mới
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayPlaceSound()
    {
        if (audioSource != null && placeSound != null)
            audioSource.PlayOneShot(placeSound);
    }

    public void PlayWinSound()
    {
        if (audioSource != null && winSound != null)
            audioSource.PlayOneShot(winSound);
    }

    public void PlayDrawSound()
    {
        if (audioSource != null && drawSound != null)
            audioSource.PlayOneShot(drawSound);
    }

    public void PlayButtonClick()
    {
        if (audioSource != null && clickButtonSound != null)
            audioSource.PlayOneShot(clickButtonSound);
    }
}
