using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour
{
    public Text m_Score, m_Time;
	public Sprite[] CharacterChoices;
	public int CharacterChoice;
	public Image PlayerChoice;
	
    void Start()
    {
        m_Score.text = "" + PlayerPrefs.GetInt("Score");
        m_Time.text = "" + PlayerPrefs.GetInt("Time");
		CharacterChoice = PlayerPrefs.GetInt ("PlayerChoice");
		PlayerChoice.sprite = CharacterChoices [CharacterChoice];

        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("StopAllMusic");

        PlayMusic("GameOver");
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
