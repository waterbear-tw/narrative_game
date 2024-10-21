using UnityEngine;
using UnityEngine.SceneManagement; // 引入場景管理

public class MainMenuManager : MonoBehaviour {
    public GameObject inkGameManagerPrefab; // InkGameManager 的 Prefab
    public AudioClip buttonClickSound; // 將按鈕點擊音效拖入這裡

    public void StartGame() {
        // 播放按鈕點擊音效，透過 AudioManager 進行管理
        AudioManager.Instance.PlaySound(buttonClickSound);

        // 生成 InkGameManager 實例
        Instantiate(inkGameManagerPrefab);
        
        // 載入遊戲場景 (根據需要)
        SceneManager.LoadScene("MainScene"); // 替換為你的遊戲場景名稱
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Game has been closed."); // 這行在編輯器中不會生效，但在打包後會執行
    }
}
