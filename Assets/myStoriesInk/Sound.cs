using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance; // 單例

    private AudioSource audioSource; // 音效源

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 使該物件跨場景不會被銷毀
        } else {
            Destroy(gameObject); // 保證只有一個 AudioManager 實例
        }

        // 獲取 AudioSource 組件
        audioSource = GetComponent<AudioSource>();
    }

    // 播放單次音效
    public void PlaySound(AudioClip clip) {
        if (audioSource != null && clip != null) {
            audioSource.PlayOneShot(clip); // 播放音效
        }
    }
}
