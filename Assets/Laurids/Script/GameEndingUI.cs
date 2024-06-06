using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameEnding : MonoBehaviour
{
    //inspector
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    //ref
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public TextMeshProUGUI scoreText;
    public GameObject pauseScreen;
    public TMP_InputField sensField;
    //
    public static bool m_playerLose;
    float m_Timer;
    private void Awake()
    {
        m_playerLose = false;
    }
    void Update()
    {
        if (m_playerLose)
        {
            EndLevel();
            scoreText.text = "Score: " + GameManager.instance.score;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            pauseScreen.SetActive(!pauseScreen.activeSelf);
            bool gamePaused = pauseScreen.activeSelf;
            Time.timeScale = gamePaused? 0 : 1;
            Cursor.lockState = gamePaused ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            //Application.Quit();
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

        }
    }
    public void RestartGame()
    {
        m_playerLose = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ChangeSpeed () 
    {
        SJS_PlayerController Control = SJS_PlayerController.instance;
        Control.speed = Control.speed == 15 ? 5 : 15;

    }
    public void changeSensitivity()
    {
        SJS_PlayerController.instance.mouseSens = float.Parse(sensField.text);
    }
}