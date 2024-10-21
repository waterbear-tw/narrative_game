using UnityEngine;

public class MainAudioManager : MonoBehaviour
{
    public static MainAudioManager Instance;  // 單例

    private AudioSource audioSource;  // 音效源

    // 播放音效和背景音樂的剪輯
    // public AudioClip backgroundMusic;
    public AudioClip choiceSelectSound;

    void Awake()
    {
        // 設置單例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 保證這個物件不會在場景切換時被銷毀
        }
        else
        {
            Destroy(gameObject);  // 確保只有一個實例
        }

        audioSource = GetComponent<AudioSource>();  // 獲取 AudioSource 組件

        if (audioSource == null) {
            Debug.LogError("AudioSource component is missing on MainAudioManager!");
        }


        // // 如果設置了背景音樂，則播放
        // if (backgroundMusic != null)
        // {
        //     PlayBackgroundMusic();
        // }
    }

    // // 播放背景音樂
    // public void PlayBackgroundMusic()
    // {
    //     if (audioSource != null && backgroundMusic != null)
    //     {
    //         audioSource.loop = true;  // 設置音樂循環播放
    //         audioSource.clip = backgroundMusic;
    //         audioSource.Play();
    //     }
    // }

    // 播放單次音效
    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);  // 播放單次音效
        }
    }
}
