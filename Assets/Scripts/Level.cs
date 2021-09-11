using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public string levelName;

    public void OnLevelButton()
    {
        SceneManager.LoadScene(levelName);
    }

}
