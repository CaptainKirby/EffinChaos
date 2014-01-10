using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {
	public float distance;
	float spawnNextModule = 0;
	
	float moduleSpacing = 5;
	public GameObject cubePrefab;
	public GameObject[] modulePrefabs;
	List<LevelModule> modules = new List<LevelModule> ();
	List<LevelModule> removers = new List<LevelModule> ();
	float offset = 100;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		distance += Time.deltaTime*5;
		if (distance > spawnNextModule) {
			GameObject go = (GameObject)Instantiate(modulePrefabs[Random.Range(0, modulePrefabs.Length)]);
			LevelModule l = go.GetComponent<LevelModule>();
			l.position = spawnNextModule;
			l.transform.position = new Vector3(0, 0, l.position-distance+offset);
			spawnNextModule += l.length;
			modules.Add(l);
			int r = Random.Range(1, 5); 
			for (int i = 0; i < r; i++) {
				GameObject g = (GameObject)Instantiate(cubePrefab);
				g.transform.parent = l.transform;
				g.transform.localPosition = new Vector3(Random.Range(0, 16)-8, Random.Range(0, 9)-5, Random.Range(0, l.length)+0.5f);
				
			}
		}
		foreach (LevelModule l in modules) {
			l.transform.position = new Vector3(0, 0, l.position-distance+offset);	
			if (l.transform.position.z < -20-l.length) {
				removers.Add(l);
			}
		}

		if (removers.Count > 0) {
			foreach (LevelModule l in removers) {
				modules.Remove(l);
				Destroy(l.gameObject);
			}
			removers.Clear();
		}
	}
}
