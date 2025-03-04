using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        public string characterName;
        [TextArea(3, 5)]
        public string[] sentences;
    }

    public GameObject dialogueUI;  // UI Paneel om aan/uit te zetten
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Button nextButton;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueUI.SetActive(false);  // Zorg dat de UI uit staat bij start
        nextButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Movement.canMove = false;
        dialogueUI.SetActive(true);  // UI aanzetten
        nameText.text = dialogue.characterName;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);  // UI verbergen na dialoog
        nameText.text = "";
        dialogueText.text = "";
        Movement.canMove = true;
    }
}
