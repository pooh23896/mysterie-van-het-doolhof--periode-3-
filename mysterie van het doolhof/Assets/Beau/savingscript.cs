using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Save : MonoBehaviour
{
    public GameObject player;
    

    public void save()

    {
        var xPos = player.transform.position.x;
        var yPos = player.transform.position.y;
        var zPos = player.transform.position.z;
        PlayerPrefs.SetFloat("X", xPos);
        PlayerPrefs.SetFloat("Y", yPos);
        PlayerPrefs.SetFloat("Z", zPos);
    }



        public void LoadPosition()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("X"),PlayerPrefs.GetFloat("Y"),PlayerPrefs.GetFloat("Z"));       

    }
 
    
}

