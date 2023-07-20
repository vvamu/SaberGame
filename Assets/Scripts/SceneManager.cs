using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Vadim2");
    }
    public void Restart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
