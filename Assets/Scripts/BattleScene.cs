using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
    }
}
