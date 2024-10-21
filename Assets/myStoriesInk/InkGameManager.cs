using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class InkGameManager : MonoBehaviour {
    public TextAsset inkJSONAsset;  // 將您的 JSON 檔案拖到這裡
    private Story story;

    [SerializeField]
    private Canvas canvas;          // 將 Canvas 拖到這裡

    [SerializeField]
    private Text textPrefab;        // 將 Text Prefab 拖到這裡

    [SerializeField]
    private Button buttonPrefab;     // 將 Button Prefab 拖到這裡

    void Awake() {
        StartStory();
    }

    void StartStory() {
        story = new Story(inkJSONAsset.text);
        RefreshView();
    }

    void RefreshView() {
        RemoveChildren();
        
        while (story.canContinue) {
            string text = story.Continue().Trim();
            CreateContentView(text);
        }

        if (story.currentChoices.Count > 0) {
            foreach (Choice choice in story.currentChoices) {
                Button button = CreateChoiceView(choice.text.Trim());
                button.onClick.AddListener(() => OnClickChoiceButton(choice));
            }
        } else {
            Button button = CreateChoiceView("End of story.\nRestart?");
            button.onClick.AddListener(StartStory);
        }
    }

    void OnClickChoiceButton(Choice choice) {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

void CreateContentView(string text) {
    Debug.Log($"Creating content view with text: {text}"); // 日誌輸出
    
    Text storyText = Instantiate(textPrefab) as Text;
    storyText.text = text;

    // 設置父物件為 TextContainer
    storyText.transform.SetParent(canvas.transform.Find("bg/TextContainer"), false);


}

Button CreateChoiceView(string text) {
    Button choiceButton = Instantiate(buttonPrefab);  // 創建按鈕實例
    
    Transform buttonContainer = canvas.transform.Find("bg/ButtonContainer"); // 找到 ButtonContainer
    if (buttonContainer != null) {
        choiceButton.transform.SetParent(buttonContainer, false);  // 將按鈕放到正確的容器中
    } else {
        Debug.LogError("ButtonContainer not found");
    }

    RectTransform rectTransform = choiceButton.GetComponent<RectTransform>();

    // // 動態設置按鈕的大小
    rectTransform.sizeDelta = new Vector2(300, 50); // 設定按鈕的寬度和高度
    
    
    // 設置按鈕文本
    Text choiceText = choiceButton.GetComponentInChildren<Text>();
    choiceText.alignment = TextAnchor.MiddleCenter; // 置中對齊
    choiceText.color = new Color(190,190,190); // 將顏色設為白色，可以改成任何其他顏色
    choiceText.text = text;
    // LayoutRebuilder.ForceRebuildLayoutImmediate(choiceButton.GetComponent<RectTransform>());

    // 設置按鈕點擊事件，並在點擊時播放音效
    choiceButton.onClick.AddListener(() => {
        // 播放選擇音效
        AudioManager.Instance.PlaySound(MainAudioManager.Instance.choiceSelectSound);
    });

    return choiceButton;
}



void RemoveChildren() {
    // 清除 TextContainer 的子物件
    Transform textContainer = canvas.transform.Find("bg/TextContainer");
    if (textContainer != null) {
        int childCount = textContainer.childCount;
        for (int i = childCount - 1; i >= 0; --i) {
            Destroy(textContainer.GetChild(i).gameObject);
        }
    }

    // 清除 ButtonContainer 的子物件
    Transform buttonContainer = canvas.transform.Find("bg/ButtonContainer");
    if (buttonContainer != null) {
        int childCount = buttonContainer.childCount;
        for (int i = childCount - 1; i >= 0; --i) {
            Destroy(buttonContainer.GetChild(i).gameObject);
        }
    }
}


}
