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
	public GameObject[] Patterns;
	public float speedIncreaseTime;
	private float speedIncreaseTimer;
	private float maxSpeed;
	// Use this for initialization
	void Start () {
		//init world
		spawnTimer = spawnTime;
		speedIncreaseTimer = speedIncreaseTime;
		maxSpeed = worldSpeed * 2.0f;
		Random.seed = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		speedIncreaseTimer -= Time.deltaTime;
		if (speedIncreaseTimer < 0.0f) {
			if(worldSpeed < maxSpeed){
			worldSpeed += (worldSpeed*0.5f);
			}
			speedIncreaseTimer = speedIncreaseTime;
		}
		transform.Translate (new Vector3 (-worldSpeed * Time.deltaTime, 0, 0));
		if (spawnTimer < 0.0f) {
			GameObject pattern = Instantiate<GameObject>(Patterns[Random.Range(0,Patterns.Length)]);
			pattern.transform.SetParent(transform);
			//make each object a random one
			for (int i = 0; i < pattern.transform.childCount; i++) {
				GameObject child = pattern.transform.GetChild(i).gameObject;
				if (child.tag == "Obstacle") {
					child = ObstacleObjects[Random.Range(0,ObstacleObjects.Length)];
				}else {
					child = PickUpObjects[Random.Range(0,PickUpObjects.Length)];
				}
			}

			spawnTimer = spawnTime;
		}
	}
}
