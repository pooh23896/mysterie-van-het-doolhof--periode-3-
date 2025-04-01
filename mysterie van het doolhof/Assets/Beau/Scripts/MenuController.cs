using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private string newGameLevel;
    
     public void NewgameButton()
       
    
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameButton()
    {
        if (PlayerPrefs.HasKey(newGameLevel))
        {
            string levelToLoad = PlayerPrefs.GetString("LoadSaved");
            SceneManager.LoadScene(levelToLoad);
        }
        
    
                
                
    }



    
}
