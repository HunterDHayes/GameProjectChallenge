using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    void Start()
    {
        PlayMusic("Gameplay");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.LoadLevel("MainMenu");
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

    public void StopAllMusic()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("StopAllMusic");
    }
}
