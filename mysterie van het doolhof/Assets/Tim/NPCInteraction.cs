using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueManager.Dialogue dialogue;

    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        dialogueManager.StartDialogue(dialogue);
        
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Druk op [E] om te praten.");
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("");
        }
    }
    
}
