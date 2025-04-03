using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject player;
    private CharacterController controller;

    void Start()
    {
        controller = player.GetComponent<CharacterController>();  // Haal CharacterController op
    }

    public void SavePosition()
    {
        var xPos = player.transform.position.x;
        var yPos = player.transform.position.y;
        var zPos = player.transform.position.z;
        PlayerPrefs.SetFloat("X", xPos);
        PlayerPrefs.SetFloat("Y", yPos);
        PlayerPrefs.SetFloat("Z", zPos);
        PlayerPrefs.Save();  // Opslaan forceren
        print("Spelerpositie opgeslagen!");
    }

    public void LoadPosition()
    {
        if (PlayerPrefs.HasKey("X") && PlayerPrefs.HasKey("Y") && PlayerPrefs.HasKey("Z"))
        {
            StartCoroutine(LoadWithController());
        }
        else
        {
            print("Geen opgeslagen positie gevonden!");
        }
    }

    IEnumerator LoadWithController()
    {
        controller.enabled = false; // Schakel CharacterController uit om directe positie-aanpassing toe te staan
        yield return new WaitForEndOfFrame(); // Wacht een frame om errors te voorkomen

        player.transform.position = new Vector3(
            PlayerPrefs.GetFloat("X"),
            PlayerPrefs.GetFloat("Y"),
            PlayerPrefs.GetFloat("Z")
        );

        yield return new WaitForEndOfFrame(); // Wacht opnieuw een frame

        controller.enabled = true; // Schakel CharacterController weer in
        print("Spelerpositie geladen!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Druk op "G" om op te slaan
        {
            SavePosition();
        }

        if (Input.GetKeyDown(KeyCode.L)) // Druk op "L" om te laden
        {
            LoadPosition();
        }
    }
}