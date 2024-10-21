using UnityEngine;

public class BgmManager : MonoBehaviour {
    public static BgmManager Instance;  // 單例模式
    public AudioClip backgroundMusic;     // 背景音樂
    private AudioSource audioSource;      // 音效源

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 使該物件在切換場景時不被銷毀
        } else {
            Destroy(gameObject); // 保證場景中只有一個 AudioManager
        }

        audioSource = GetComponent<AudioSource>(); // 獲取 AudioSource 組件
    }

    void Start() {
        // 播放背景音樂
        PlayMusic(backgroundMusic);
    }

    public void PlayMusic(AudioClip clip) {
        if (clip != null && audioSource != null) {
            audioSource.clip = clip;
            audioSource.Play(); // 開始播放音樂
        }
    }

    public void StopMusic() {
        if (audioSource.isPlaying) {
            audioSource.Stop(); // 停止音樂
        }
    }
}
