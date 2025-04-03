using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Save : MonoBehaviour
{
    public GameObject player;
    

    public void save()

    {
        var xPos = player.transform.position.x;   // coördinaten worden opgehaald position 
        var yPos = player.transform.position.y;
        var zPos = player.transform.position.z;
        PlayerPrefs.SetFloat("X", xPos);        // waarden in opgeslagen
        PlayerPrefs.SetFloat("Y", yPos);
        PlayerPrefs.SetFloat("Z", zPos);
    }



        public void LoadPosition()
    {
      player.transform.position = new Vector3(PlayerPrefs.GetFloat("X"),PlayerPrefs.GetFloat("Y"),PlayerPrefs.GetFloat("Z"));       // worden de opgeslagen waarden opgehaald

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Druk op "S" om op te slaan
        {
            save();
            Debug.Log("Spelerpositie opgeslagen!");
        }

        if (Input.GetKeyDown(KeyCode.L)) // Druk op "L" om te laden
        {
            LoadPosition();
            Debug.Log("Spelerpositie geladen!");  
        }
    }

}

