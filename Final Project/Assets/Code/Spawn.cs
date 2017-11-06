using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	
	// Spawnee = Resources.Load("Mook");
	// Use this for initialization
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		hazard = Resources.Load("Mook") as GameObject;
		hazardCount = 5;
		spawnValues = gameObject.transform.position;
		spawnWait = 1.0f;
		startWait = 2.0f;
		waveWait = 2.0f;
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				// Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnValues, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
