using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nikita2");
    }
}
