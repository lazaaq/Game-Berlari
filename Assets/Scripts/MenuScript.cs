using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Update is called once per frame
    void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
