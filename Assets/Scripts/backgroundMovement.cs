using UnityEngine;
using System.Collections;

public class backgroundMovement : MonoBehaviour {
	public GameObject background1;
	public GameObject background2;
	public float worldSpeed;
	public float speedIncreaseTime;
	private float speedIncreaseTimer;
	private float maxSpeed;
	private float disBetween;
	// Use this for initialization
	void Start () {
		disBetween =  background1.transform.position.x - background2.transform.position.x ;
		maxSpeed = 2 * worldSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-worldSpeed * Time.deltaTime, 0, 0));
		if (speedIncreaseTimer < 0.0f) {
			if (worldSpeed < maxSpeed) {
				worldSpeed += (worldSpeed * 0.5f);
			}
			speedIncreaseTimer = speedIncreaseTime;
		}
		if (background1.transform.position.x < -17.0f) {
			background1.transform.position = new Vector3((background1.transform.position.x + 17.0f) + disBetween,background1.transform.position.y,background1.transform.position.z);
		}
		if (background2.transform.position.x < -17.0f) {
			background2.transform.position = new Vector3((background2.transform.position.x + 17.0f) + disBetween,background2.transform.position.y,background2.transform.position.z);
		}
	}
}
