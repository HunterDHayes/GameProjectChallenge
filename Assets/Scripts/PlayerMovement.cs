using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float liftForce;
	private Rigidbody2D rigid;
	private Collider2D col;
	private bool alive = true;
	private int score = 0;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//input


			
	}
	void FixedUpdate(){
		if (alive) {
			if (Input.GetMouseButton (0)) {
				rigid.AddForce (new Vector2 (0, (liftForce * Time.deltaTime)));
			}
		}
		if (Input.GetKey(KeyCode.R)) {
			alive = true;
			transform.position = new Vector3(-4.0f,0.0f,0.0f);
			rigid.velocity = new Vector2(0,0);
		}
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("hit something");
	}

	void OnTriggerEnter2D(Collider2D collided){
		if (collided.tag == "Cloud") {
			Debug.Log ("hit a cloud");
			Death();
		} else if(collided.tag == "Obstacle"){
			Debug.Log ("hit an obstacle");
			Death();
		}else if(collided.tag == "PickUp"){
			Debug.Log ("hit a PickUp");
			collided.GetComponent<SpriteRenderer>().enabled = false;
			collided.GetComponent<PolygonCollider2D>().enabled = false;
			score += 10;
		}else {
			Debug.Log ("triggered something");
		}
	}
	void Death(){
		rigid.AddForce (new Vector2 (0, -50));
		PlayerPrefs.SetInt("Score",score);
		score = 0;

		alive = false;
	}
}
