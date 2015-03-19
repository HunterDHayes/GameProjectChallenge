using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {
	public GameObject player;	
	public float worldSpeed;
	public float spawnTime;
	private float spawnTimer;
	public GameObject PickUp;
	public GameObject Obstacle;
	public GameObject[] PickUpObjects;
	public GameObject[] ObstacleObjects;
	// Use this for initialization
	void Start () {
		//init world
		spawnTimer = spawnTime;
		Random.seed = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-worldSpeed * Time.deltaTime, 0, 0));
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 0.0f) {
			//spawn an item
			float randomFloat = Random.Range(-1.0f,1.0f);
			float offset = Random.Range(-3.2f,3.2F);
			Debug.Log(offset);
			if (randomFloat > 0) {
				//spawn pick up
				GameObject newPickUp = Instantiate<GameObject>(PickUpObjects[Random.Range(0,PickUpObjects.Length)]);
				//set position
				newPickUp.transform.SetParent(transform);
				newPickUp.transform.position = Vector3.zero;
				newPickUp.transform.Translate(new Vector3(10,offset));
				newPickUp.tag = "PickUp";

			} else {
				//spawn obstacle
				GameObject newObstacle = Instantiate<GameObject>(ObstacleObjects[Random.Range(0,ObstacleObjects.Length)]);
				//set position
				newObstacle.transform.SetParent(transform);
				newObstacle.transform.position = Vector3.zero;
				newObstacle.transform.Translate(new Vector3(10,offset,0));
				newObstacle.tag = "Obstacle";
			
			}
			spawnTimer = spawnTime;
		}
	}
}
