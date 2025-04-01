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
        [TextArea(3, 5)]
        public string[] lines;
    }

    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;

    private Queue<string> dialogueQueue;

    void Start()
    {
        dialogueQueue = new Queue<string>();
        dialogueUI.SetActive(false);
        nextButton.onClick.AddListener(DisplayNextLine);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Movement.canMove = false;
        dialogueUI.SetActive(true);
        dialogueQueue.Clear();

        foreach (string line in dialogue.lines)
        {
            dialogueQueue.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueQueue.Dequeue();
        StopAllCoroutines();  // Een courotine gaat over meerder frames heen
        StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine(string line) // yield return 
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogueText.text = "";
        Movement.canMove = true;
    }
} 