using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour
{
    public Text m_Score, m_Time, m_Grade;

    void Start()
    {
        m_Score.text = "" + PlayerPrefs.GetInt("Score");
        m_Time.text = "" + (int)PlayerPrefs.GetFloat("Time") + " secs";

        float grade = PlayerPrefs.GetInt("Score") / PlayerPrefs.GetFloat("Time");
        PlayerPrefs.SetFloat("TotalGrade", PlayerPrefs.GetFloat("TotalGrade") + grade);


        m_Grade.text = "D";
        if (grade > 3)
            m_Grade.text = "C";
        else if (grade > 5)
            m_Grade.text = "B";
        else if (grade > 7)
            m_Grade.text = "A";

        PlayMusic("Endscreen");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.LoadLevel("FrontEnd");
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
