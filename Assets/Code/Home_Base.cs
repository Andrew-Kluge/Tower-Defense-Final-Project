using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Base : MonoBehaviour
{

	private Health_Bar _survival;
	private float _health;
    public float _money;
	public Slider slider;
    public Text money_text;
	
	// Use this for initialization
	void Start ()
	{
		slider = FindObjectOfType<Slider>();
		_health = slider.value;
		_survival = GetComponent<Health_Bar>();
        _money = 10.0f;
        money_text = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();

        money_text.text = "$" + _money.ToString();
	}

	private void OnCollisionEnter(Collision other)
	{
		_health -= 10;
		if (_health < 0)
			slider.value = 0;
		else
		{
			slider.value = _health;
		}
		
	}

    public void ChangeMoney(float amount)
    {
        _money += amount;
        money_text.text = "$" + _money;
    }

	// Update is called once per frame
	void Update ()
	{
	}
}
