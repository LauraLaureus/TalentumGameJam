using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void loadMyScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
