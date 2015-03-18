using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {
	public GameObject player;	
	public float worldSpeed;
	public float spawnTime;
	private float spawnTimer;
	public GameObject PickUp;
	public GameObject Obstacle;
	// Use this for initialization
	void Start () {
		//init world
		spawnTimer = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-worldSpeed * Time.deltaTime, 0, 0));
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 0.0f) {
			//spawn an item
			if (Random.Range(0,1) > 0) {
				//spawn pick up
				GameObject newPickUp = Instantiate<GameObject>(PickUp);
				//set position
				newPickUp.transform.Translate(new Vector3(4,0,0));
				newPickUp.transform.SetParent(transform);
			} else {
				//spawn obstacle
				GameObject newObstacle = Instantiate<GameObject>(Obstacle);
				//set position
				newObstacle.transform.Translate(new Vector3(4,0,0));
				newObstacle.transform.SetParent(transform);
			}
			spawnTimer = spawnTime;
		}
	}
}
