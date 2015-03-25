using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour
{
    public Text m_Score, m_Time, m_Grade;
    public float m_Timer;
    private float grade;
    private bool played = false;

    void Start()
    {
        m_Score.text = "" + PlayerPrefs.GetInt("Score");
        m_Time.text = "" + (int)PlayerPrefs.GetFloat("Time") + " secs";

        grade = PlayerPrefs.GetInt("Score") / PlayerPrefs.GetFloat("Time");
        PlayerPrefs.SetFloat("TotalGrade", PlayerPrefs.GetFloat("TotalGrade") + grade);

        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("PlaySfx", "GameOver");
		
		m_Grade.text = "D";

        if (grade > 3)
        {
            m_Grade.text = "C";
        }
        if (grade > 5)
        {
            m_Grade.text = "B";
        }
        if (grade > 7)
        {
            m_Grade.text = "A";
        }

        PlayMusic("Endscreen");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.LoadLevel("FrontEnd");

        m_Timer -= Time.deltaTime;
        if (m_Timer < 0.0f && !played)
        {
            if (grade > 3)
            {
                GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
                if (soundManager)
                    soundManager.SendMessage("PlaySfx", "C");
            }
            else if (grade > 5)
            {
                GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
                if (soundManager)
                    soundManager.SendMessage("PlaySfx", "B");
            }
            else if (grade > 7)
            {
                GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
                if (soundManager)
                    soundManager.SendMessage("PlaySfx", "A");
            }
            else
            {
                GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
                if (soundManager)
                    soundManager.SendMessage("PlaySfx", "D");
            }
            played = true;
        }
    }

    public void ChangeScene(string name)
    {
        Application.LoadLevel(name);
    }

    public void PlayMusic(string name)
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("PlayMusic", name);
    }

    public void PlaySFX(string name)
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("PlaySfx", name);
    }
}
