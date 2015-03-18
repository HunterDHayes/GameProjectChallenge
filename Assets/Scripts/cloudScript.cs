using UnityEngine;
using System.Collections;

public class cloudScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -10.0f) {
			transform.position = new Vector3(10.0f,transform.position.y,transform.position.z);
		}
	}
	void OnBecameInvisible(){
		transform.position = new Vector3 (4.9f, transform.position.y);
	}
}
