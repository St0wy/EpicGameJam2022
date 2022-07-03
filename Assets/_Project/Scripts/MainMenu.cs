using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EpicGameJam
{
    public class MainMenu : MonoBehaviour
    {

        public void StartGame()
        { 
        
            //Application.LoadLevel("Level01");
            SceneManager.LoadScene("AndréScene"); 
       
        }

       
        public void ExitGame()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}
