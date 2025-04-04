using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventoryUI; // De inventory canvas (UI)
    private bool isOpen = false; // Houdt bij of de inventory open is
    private MouseLook mouseLook;

    void Start()
    {
        // Zorgt dat de inventory gesloten is bij de start van het spel
        inventoryUI.SetActive(false);  // Inventory is gesloten bij starten

        mouseLook = FindObjectOfType<MouseLook>(); // Vindt de camera controller
    }

    void Update()
    {
        // Alleen de inventory openen wanneer "I" wordt ingedrukt
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            ToggleInventory();  // Wisselt de status van de inventory (open/sluit)
        }
    }

    void ToggleInventory()
    {
        // Wissel de status van de inventory (open of gesloten)
        isOpen = !isOpen;
        inventoryUI.SetActive(isOpen);  // Als open, wordt de canvas geactiveerd, anders niet

        Debug.Log("Inventory status: " + (isOpen ? "Open" : "Gesloten"));

        // Wanneer de inventory wordt geopend of gesloten, werken we de muiscursor en camera bij
        if (isOpen)
        {
            LockCursor(); // Muis wordt zichtbaar en camera vergrendeld
        }
        else
        {
            UnlockCursor(); // Muis wordt verborgen en camera wordt ontgrendeld
        }
    }

    void LockCursor()
    {
      
       
        if (mouseLook != null)
        {
            mouseLook.LockCamera(); // Camera beweging wordt uitgeschakeld
        }
    }

    void UnlockCursor()
    {

     
        if (mouseLook != null)
        {
            mouseLook.UnlockCamera(); // Camera beweging wordt ingeschakeld
        }
    }
}
