using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Snelheid van de muisbeweging
    public Transform playerBody; // Het object dat de speler representeert

    private float xRotation = 0f;
    private bool canMove = true; // Controleert of de camera mag bewegen

    void Start()
    {
        
    }

    void Update()
    {
        if (!canMove) return; // Stop als de camera vergrendeld is

        // Verkrijg de muisbeweging
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotatie rond de x-as (omhoog/omlaag)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Beperk de verticale rotatie

        // Draai de camera (voor de kijkrichting omhoog/omlaag)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Draai de speler (voor de horizontale rotatie van het lichaam)
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Functie om de camera te vergrendelen (bijvoorbeeld tijdens een gesprek of inventory)
    public void LockCamera()
    {
        canMove = false;
        
        
    }

    // Functie om de camera te ontgrendelen (na het gesprek of als de inventory sluit)
    public void UnlockCamera()
    {
        canMove = true;
        
        
    }
}
