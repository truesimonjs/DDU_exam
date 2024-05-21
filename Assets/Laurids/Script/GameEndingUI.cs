using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public TextMeshProUGUI scoreText;
    public static bool m_playerLose;
    float m_Timer;

    void Update()
    {
        if (m_playerLose)
        {
            EndLevel();
            scoreText.text = "Score: " + GameManager.instance.score;
        }
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}