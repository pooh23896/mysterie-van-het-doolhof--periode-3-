using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Snelheid van de muisbeweging
    public Transform playerBody; // Het object dat je speler representeert (waar de camera aan vastzit)

    private float xRotation = 0f;

    void Start()
    {
    
    }

    void Update()
    {
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
}