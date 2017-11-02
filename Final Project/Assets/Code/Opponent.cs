using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{

	private int _killit;
	
	// Use this for initialization
	void Start ()
	{
		_killit = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_killit <= 0)
			Die();
	}

	void Die()
	{
		Destroy
	}
}
