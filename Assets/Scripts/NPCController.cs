using System.Collections;
using TMPro;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    [Header("UI 绑定")]
    public GameObject dialogueUI;             // 对话框 Canvas
    public GameObject panel;                  // 对话框面板（Image）
    public TextMeshProUGUI dialogueText;      // 文本对象

    [Header("对话内容")]
    [TextArea] public string dialogueContent; // 对话文本
    public float typingSpeed = 0.05f;         // 打字速度

    void Start()
    {
        dialogueUI.SetActive(false);  // 初始隐藏
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);  // 显示对话框
            StopAllCoroutines();
            StartCoroutine(TypeText(dialogueContent));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(false);  // 离开时隐藏
            StopAllCoroutines();
        }
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        panel.SetActive(true);
        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
