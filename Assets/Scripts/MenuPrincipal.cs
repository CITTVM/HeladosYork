using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour{

    public string startLevel;
    
    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    
}
