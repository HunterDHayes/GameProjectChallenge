using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float liftForce;
	private Rigidbody2D rigid;
	private Collider2D col;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//input

		if (Input.GetMouseButtonDown(0)) {
			rigid.AddForce(new Vector2(0,(liftForce*Time.deltaTime)));
		}
			
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("hit something");
	}

	void OnTriggerEnter2D(Collider2D collided){
		if (collided.tag == "Cloud") {
			Debug.Log ("hit a cloud");
		} else {
			Debug.Log ("triggered something");
		}
	}
}
