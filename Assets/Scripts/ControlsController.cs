using UnityEngine;
using System.Collections;

public class ControlsController : MonoBehaviour {

	public float m_RenderTime;
	private float m_Timer;

	// Use this for initialization
	void Start () {
		m_Timer = m_RenderTime;
	}
	
	// Update is called once per frame
	void Update () {
		m_Timer -= Time.deltaTime;

		if (m_Timer <= 0.0f || Input.GetMouseButtonDown (0))
			Destroy (gameObject);
	}
}
