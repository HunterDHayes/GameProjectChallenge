using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] m_CanvasList;
    private string m_sCurrentCanvas;

    private int m_nNumOperatorsSelected;
    public Button m_OperatorNextButton, m_DifficultyPlayButton;
    public Button[] m_OperatorDeselectButtons, m_OperatorSelectButtons, m_DifficultyDeselectButtons, m_DifficultySelectButtons;
    public Button m_OperatorVerticalRenderButton, m_OperatorHorizontalRenderButton;
    public Text m_Highscore, m_PercentCorrect, m_TotalPopped;

    void Start()
    {
        if (!GlobalData.GetGlobalData().RenderedSplashScreens)
            ActivateCanvas("Splash Screen");
        else
            ActivateCanvas("Main Menu");

        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("PlayMusic", "MainMenu");

        m_OperatorNextButton.gameObject.SetActive(false);
        m_DifficultyPlayButton.gameObject.SetActive(false);

        if (PlayerPrefs.GetString("EquationRenderSelection") != "")
            EquationRenderSelection(PlayerPrefs.GetString("EquationRenderSelection"));
        else
            EquationRenderSelection("Horizontal");

        m_Highscore.text = "" + PlayerPrefs.GetInt("Highscore");

        if (PlayerPrefs.GetInt("TotalPopped") == 0)
            m_PercentCorrect.text = "0 %";
        else
        {
            float fPercentCorrect = (PlayerPrefs.GetInt("TotalCorrect") * 1.0f / PlayerPrefs.GetInt("TotalPopped"));
            string text = "" + fPercentCorrect;
            if (text.Length > 5)
                text.Insert(5, "\0");
            m_PercentCorrect.text = "" + text + " %";
        }

        m_TotalPopped.text = "" + PlayerPrefs.GetInt("TotalPopped");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            switch (m_sCurrentCanvas)
            {
                default:
                case "Main Menu":
                    ExitGame();
                    break;
                case "Operator":
                case "Options":
                    ActivateCanvas("Main Menu");
                    OperatorAllDeselected();
                    break;
                case "Difficulty":
                    ActivateCanvas("Operator");
                    DifficultySelected(-1);
                    break;
                case "Stats":
                case "Credits":
                    ActivateCanvas("Options");
                    break;
            }
        }
    }

    public void ChangeScene(string name)
    {
        Application.LoadLevel(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ActivateCanvas(string name)
    {
        for (int i = 0; i < m_CanvasList.Length; i++)
        {
            m_CanvasList[i].SetActive(false);

            if (m_CanvasList[i].name == name)
            {
                m_CanvasList[i].SetActive(true);
                m_sCurrentCanvas = name;
            }
        }
    }

    public void ShowMoreGames()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/developer?id=CelleC+Games,+Inc.");
#elif UNITY_IOS
		//Application.OpenURL("https://itunes.apple.com/us/app/math-slash/id839489559?mt=8");
#else
        Application.OpenURL("https://play.google.com/store/apps/developer?id=CelleC+Games,+Inc.");
#endif
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

    public void StopAllSfx()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("StopAllSfx");
    }

    public void MuteAllMusic()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("MuteAllMusic");
    }

    public void MuteAllSfx()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("MuteAllSfx");
    }

    public void UnmuteAllMusic()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("UnmuteAllMusic");
    }

    public void UnmuteAllSfx()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("UnmuteAllSfx");
    }

    public void OperatorSelected(int _nOperator)
    {
        if (!GlobalData.GetGlobalData().m_bOperatorsOn[_nOperator])
            m_nNumOperatorsSelected++;

        GlobalData.GetGlobalData().m_bOperatorsOn[_nOperator] = true;
        m_OperatorNextButton.gameObject.SetActive(true);

    }

    public void OperatorDeselected(int _nOperator)
    {
        if (GlobalData.GetGlobalData().m_bOperatorsOn[_nOperator])
            m_nNumOperatorsSelected--;

        GlobalData.GetGlobalData().m_bOperatorsOn[_nOperator] = false;

        if (m_nNumOperatorsSelected == 0)
            m_OperatorNextButton.gameObject.SetActive(false);
    }

    public void OperatorAllSelected()
    {
        m_nNumOperatorsSelected = 4;

        for (int i = 0; i < GlobalData.GetGlobalData().m_bOperatorsOn.Length; i++)
            GlobalData.GetGlobalData().m_bOperatorsOn[i] = true;

        m_OperatorNextButton.gameObject.SetActive(true);

        for (int i = 0; i < m_OperatorDeselectButtons.Length; i++)
            m_OperatorDeselectButtons[i].gameObject.SetActive(false);
        for (int i = 0; i < m_OperatorSelectButtons.Length; i++)
            m_OperatorSelectButtons[i].gameObject.SetActive(true);

    }

    public void OperatorAllDeselected()
    {
        m_nNumOperatorsSelected = 0;

        for (int i = 0; i < GlobalData.GetGlobalData().m_bOperatorsOn.Length; i++)
            GlobalData.GetGlobalData().m_bOperatorsOn[i] = false;

        m_OperatorNextButton.gameObject.SetActive(false);

        for (int i = 0; i < m_OperatorDeselectButtons.Length; i++)
            m_OperatorDeselectButtons[i].gameObject.SetActive(true);
        for (int i = 0; i < m_OperatorSelectButtons.Length; i++)
            m_OperatorSelectButtons[i].gameObject.SetActive(false);
    }

    public void DifficultySelected(int _nDifficulty)
    {
        for (int i = 0; i < m_DifficultyDeselectButtons.Length; i++)
            m_DifficultyDeselectButtons[i].gameObject.SetActive(true);

        for (int i = 0; i < m_DifficultySelectButtons.Length; i++)
            m_DifficultySelectButtons[i].gameObject.SetActive(false);

        m_DifficultyPlayButton.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Difficulty", _nDifficulty + 1);

        if (_nDifficulty != -1)
        {
            m_DifficultyDeselectButtons[_nDifficulty].gameObject.SetActive(false);
            m_DifficultySelectButtons[_nDifficulty].gameObject.SetActive(true);
            m_DifficultyPlayButton.gameObject.SetActive(true);
        }
    }

    public void EquationRenderSelection(string _RenderOption)
    {
        m_OperatorVerticalRenderButton.gameObject.SetActive(false);
        m_OperatorHorizontalRenderButton.gameObject.SetActive(false);
        PlayerPrefs.SetString("EquationRenderSelection", _RenderOption);

        if (_RenderOption == "Vertical")
            m_OperatorVerticalRenderButton.gameObject.SetActive(true);
        else if (_RenderOption == "Horizontal")
            m_OperatorHorizontalRenderButton.gameObject.SetActive(true);
    }

    public void ResetStats()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetInt("TotalCorrect", 0);
        PlayerPrefs.SetInt("TotalPopped", 0);

        m_Highscore.text = "0";
        m_PercentCorrect.text = "0 %";
        m_TotalPopped.text = "0";
    }
}
