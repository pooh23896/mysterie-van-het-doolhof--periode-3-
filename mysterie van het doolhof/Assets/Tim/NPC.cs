using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public DialogueManager.Dialogue dialogue = new DialogueManager.Dialogue
    {
        characterName = "NPC",
        sentences = new string[]
        {
            "Hallo, avonturier!",
            "Welkom in onze wereld.",
            "Veel succes op je reis!"
        }
    };

    public void StartConversation()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
