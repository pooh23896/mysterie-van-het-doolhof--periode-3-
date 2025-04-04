using UnityEngine;

public class ButtonWallRemover : MonoBehaviour
{
    public GameObject wallToRemove; // Sleep hier de muur in vanuit de Inspector
    public string wallName; // Naam van de muur, in te stellen in de Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check of de speler de knop raakt
        {
            if (wallToRemove != null)
            {
                wallToRemove.SetActive(false); // Verwijdert de muur
                Debug.Log("Muur " + wallName + " is verwijderd!");
            }
        }
    }
}

