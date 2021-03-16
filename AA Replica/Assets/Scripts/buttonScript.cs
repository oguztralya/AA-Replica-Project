using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    
    public void playGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("saveLevel",1));
    }

    public void quit()
    {
        Application.Quit();
    }

    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
