using UnityEngine;
using System.Collections;

public class LaptopDestro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		if (PlayerPrefs.GetInt ("ChangingScenes") != 0) {
			GameObject soundManager = GameObject.FindGameObjectWithTag ("SoundManager");
			soundManager.SendMessage ("PlaySfx", "Laptop");
		}
	}
}
