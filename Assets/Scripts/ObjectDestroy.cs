using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{

    public string m_DeathSfxName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        if (PlayerPrefs.GetInt("ChangingScenes") != 0)
        {
            GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

            if (soundManager)
                soundManager.SendMessage("PlaySfx", m_DeathSfxName);
        }
    }
}
