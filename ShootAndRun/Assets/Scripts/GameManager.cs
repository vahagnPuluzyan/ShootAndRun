using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameObject startButton;
    public Animator characterAnimator;
    public GameObject finishUi;
    public TextMeshProUGUI levelText;
    public GameObject shopButton;

    GameObject joystick;

    void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>().gameObject;
        _instance = this;
        Time.timeScale = 0;
        joystick.SetActive(false);
        levelText.text = "Level " + LevelManager._instance.currentLevel.ToString();
    }

    public void GameOver()
    {
        LevelManager._instance.ReplayScene();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        characterAnimator.SetBool("Run", true);
        startButton.SetActive(false);
        joystick.SetActive(true);
        shopButton.SetActive(false);
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        finishUi.SetActive(true);
        characterAnimator.SetBool("Run",false);
    }

    public void NextLevel()
    {
        LevelManager._instance.NextLevel();
        LevelManager._instance.RandomScene();
    }
}
