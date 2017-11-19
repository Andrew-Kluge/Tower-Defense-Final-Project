using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour {
	
	// Spawnee = Resources.Load("Mook");
	// Use this for initialization
	public GameObject hazardAv;
    public GameObject hazardSpeedy;
    public GameObject hazardHeavy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public int avCount;
    public int speedyCount;
    public int heavyCount;
    private List<int> enemy_wave;
    private int waveNum;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		hazardAv = Resources.Load("Mook") as GameObject;
        hazardHeavy = Resources.Load("Heavy2") as GameObject;
        hazardSpeedy = Resources.Load("Speedy") as GameObject;
        hazardCount = 5;
		spawnValues = gameObject.transform.position;
		spawnWait = 1.0f;
		startWait = 10.0f;
		waveWait = 4.0f;
        waveNum = 1;
        enemy_wave = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            enemy_wave.Add(Mathf.RoundToInt(Random.Range(1.0f, 3.0f)));
            
        }
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
            //show how many of each enemy is coming
            avCount = enemy_wave.FindAll(delegate (int j) { return j == 1; }).Count;
            speedyCount = enemy_wave.FindAll(delegate (int j) { return j == 2; }).Count;
            heavyCount = enemy_wave.FindAll(delegate (int j) { return j == 3; }).Count;
            //spawn enemies from array
            foreach (var i in enemy_wave)
			{
                CreateEnemy(i);
                



                yield return new WaitForSeconds(spawnWait);

            }

            //populate next rounds enemies array
            if (waveNum % 2 == 0)
            {
                hazardCount++;
            }
            for (int i = 0; i < hazardCount; i++)
            {
                enemy_wave.Add(Mathf.RoundToInt(Random.Range(1.0f, 3.0f)));

            }
            waveNum++;

            yield return new WaitForSeconds(waveWait);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

    private void CreateEnemy(int enemy_type)
    {
        Quaternion spawnRotation = Quaternion.identity;
        if (enemy_type == 1)
        {
            Instantiate(hazardAv, spawnValues, spawnRotation);
        }
        else if (enemy_type == 2)
        {
            Instantiate(hazardSpeedy, spawnValues, spawnRotation);
        }
        else
        {
            Instantiate(hazardHeavy, spawnValues, spawnRotation);
        }
    }
}
