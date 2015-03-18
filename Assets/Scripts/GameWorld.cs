using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {
	public GameObject player;	
	public float worldSpeed;
	// Use this for initialization
	void Start () {
		//init world
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-worldSpeed * Time.deltaTime, 0, 0));
		//for (int i = 0; i < GetComponentInChildren<Transform>(); i++) {
		//
		//}
	}
}
