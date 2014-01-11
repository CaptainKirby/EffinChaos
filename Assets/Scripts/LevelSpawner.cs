using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {
	public static LevelSpawner instance;
	public float distance;
	float spawnNextModule = 0;
	public GameObject tubePrefab;
	public GameObject cubePrefab;
	public GameObject[] modulePrefabs;
	List<LevelModule> modules = new List<LevelModule> ();
	List<LevelModule> removers = new List<LevelModule> ();
	float offset = 150;
	public float speed = 10;
	int tubeLength = 10;
	public int nextTube = 0;
	List<LevelModule> tubes = new List<LevelModule> ();

	// Use this for initialization
	void Awake () {
		instance = this;
		// Populating the map with tubes, so it is not empty at start
		for (int i = 0; i < 15; i++) {
			GameObject go = (GameObject)Instantiate(tubePrefab);
			LevelModule l = go.GetComponent<LevelModule>();
			l.position = i*tubeLength-offset;
			l.transform.position = new Vector3(0, -4.5f, l.position-distance+offset);
			tubes.Add(l);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		speed += (Time.deltaTime / speed) * 10;
		distance += Time.deltaTime*speed;

		//Adding tube pieces
		if (distance > nextTube) {
			GameObject go = (GameObject)Instantiate(tubePrefab);
			LevelModule l = go.GetComponent<LevelModule>();
			l.position = nextTube;
			l.transform.position = new Vector3(0, -4.5f, l.position-distance+offset);
			tubes.Add(l);
			nextTube += tubeLength;
		}

		//Updating tube pieces position
		foreach (LevelModule l in tubes) {
			l.transform.position = new Vector3(0, -4.5f, l.position-distance+offset);	
			if (l.transform.position.z < -20-l.length) removers.Add(l);
		}

		//Removing tube pieces that have passed the player
		if (removers.Count > 0) {
			foreach (LevelModule l in removers) {
				tubes.Remove(l);
				Destroy(l.gameObject);
			}
			removers.Clear();
		}
		
		//Adding next module
		if (distance > spawnNextModule) {
			GameObject prefab = modulePrefabs[Random.Range(0, modulePrefabs.Length)];
			GameObject go = (GameObject)Instantiate(prefab);
			LevelModule l = go.GetComponent<LevelModule>();
			l.position = spawnNextModule;
			l.transform.position = new Vector3(0, 0, l.position-distance+offset);
			Rigidbody ri = l.gameObject.AddComponent<Rigidbody>();
			ri.isKinematic = true;
			ri.MovePosition(new Vector3(0, 0, l.position-distance+offset));
			spawnNextModule += l.length;
			modules.Add(l);
			if (l.fillWithRandomBlocks) {
				int r = Random.Range(1, 5); 
				for (int i = 0; i < r; i++) {
					GameObject g = (GameObject)Instantiate(cubePrefab);
					g.transform.parent = l.transform;
					g.transform.localPosition = new Vector3(Random.Range(0, 16)-8, Random.Range(0, 9)-5, Random.Range(0, l.length)+0.5f);				
				}
			}
		}

		//Updating all spawned modules position
		foreach (LevelModule l in modules) {
			l.rigidbody.MovePosition(new Vector3(0, 0, l.position-distance+offset));
			//l.transform.position = new Vector3(0, 0, l.position-distance+offset);	
			if (l.transform.position.z < -20-l.length) removers.Add(l);
		}
		
		//Removing modules that have passed the player
		if (removers.Count > 0) {
			foreach (LevelModule l in removers) {
				modules.Remove(l);
				Destroy(l.gameObject);
			}
			removers.Clear();
		}
	}
}
