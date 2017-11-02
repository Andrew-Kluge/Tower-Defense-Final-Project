using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Base : MonoBehaviour
{

	private Health_Bar _survival;
	private float _health;
	public Slider slider;
	
	// Use this for initialization
	void Start ()
	{
		slider = FindObjectOfType<Slider>();
		_health = slider.value;
		_survival = GetComponent<Health_Bar>();
	}

	private void OnCollisionEnter(Collision other)
	{
		_health -= 20;
		if (_health < 0)
			slider.value = 0;
		else
		{
			slider.value = _health;
		}
		
	}

	// Update is called once per frame
	void Update ()
	{
	}
}
