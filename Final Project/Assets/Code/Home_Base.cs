using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Base : MonoBehaviour
{

	private Health_Bar _survival;
	private int _health;
	
	// Use this for initialization
	void Start ()
	{
		_health = 0;
		_survival = GetComponent<Health_Bar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
