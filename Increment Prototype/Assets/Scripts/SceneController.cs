using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;  
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
