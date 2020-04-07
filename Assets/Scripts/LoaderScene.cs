using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoaderScene : MonoBehaviour
{
    // public void LoadNextScene()
    // {
    //     int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(activeSceneIndex + 1, LoadSceneMode.Single);
    // }
    
    public void LoadNextSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
