using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager _instance;

    public int currentScene;
    public int currentLevel;

    private void Start()
    {
        _instance = this;
        currentScene = PlayerPrefs.GetInt("CurrentScene");
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");

        if (currentScene == 0)
        {
            PlayerPrefs.SetInt("CurrentScene", 1);
            currentScene = 1;
            SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
        }
        if (currentLevel == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel",1);
            currentLevel = 1;
        } 
    }

    public void NextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel",currentLevel);
    }

    public void RandomScene()
    {
        SceneManager.UnloadSceneAsync(currentScene);
        currentScene = Random.Range(1,SceneManager.sceneCountInBuildSettings - 1);
        PlayerPrefs.SetInt("CurrentScene",currentScene);
        SceneManager.LoadScene(currentScene,LoadSceneMode.Additive);
    }
    
    public void ReplayScene()
    {
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
    }
}
