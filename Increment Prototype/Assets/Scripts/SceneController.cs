using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is only for scene management, allowing for easy loading of different scenes in the game and handling application quit functionality.
public class SceneController : MonoBehaviour
{
    [Header("Scenes")]
    public string gameScene;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
