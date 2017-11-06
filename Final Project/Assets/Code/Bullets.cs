using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public Transform _targ;
	private float _velocity;
	private float _lifetime;
	private float _starttime;
	
	
	// Use this for initialization
	public void Initialize (GameObject target)
	{
		_velocity = 5f;
		_targ = target.transform;
		_lifetime = 1f;
		_starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _lifetime + _starttime)
			Die();
		transform.position = Vector3.MoveTowards(transform.position,
			new Vector3(_targ.position.x, transform.position.y, _targ.position.z), _velocity * Time.deltaTime);
	}
	
	private void OnCollisionEnter(Collision other)
	{
		Die();
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
}
