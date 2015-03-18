using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour
{
    // This class holds all of the data that should persist between scenes
    #region Data Members
    static private GlobalData m_instance;

    public bool[] m_bOperatorsOn;

    [SerializeField]
    private bool m_RenderedSplashScreens;

    public enum PauseStates { UNPAUSED, PAUSED, };
    #endregion

    public static GlobalData GetGlobalData()
    {
        return m_instance;
    }

    #region Accessors and Mutators
    public bool RenderedSplashScreens
    {
        set { m_RenderedSplashScreens = value; }
        get { return m_RenderedSplashScreens; }
    }
    #endregion

    #region Unity Functions
    void Awake()
    {
        if (m_instance != null && this != m_instance)
        {
            Destroy(this);
            return;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            m_instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        PlayerPrefs.SetInt("Paused", (int)PauseStates.UNPAUSED);

        m_bOperatorsOn = new bool[4];

        for (int i = 0; i < m_bOperatorsOn.Length; i++)
            m_bOperatorsOn[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    #endregion

    #region Functions
    #endregion
}
