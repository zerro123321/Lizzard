using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string nextLevelSceenName = "Level 2";
    public void StartGame()
    {

        SceneManager.LoadScene(nextLevelSceenName);

    }
}
