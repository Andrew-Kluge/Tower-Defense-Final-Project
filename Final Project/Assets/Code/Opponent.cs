using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Code
{
	public class Opponent : MonoBehaviour
	{

		public int _killit;
		public Transform _targ;
		private float _velocity;

		// Use this for initialization
		void Start()
		{
			_killit = 10;
			_targ = GameObject.FindGameObjectWithTag("Base").transform;
			_velocity = 1.0f;
		}

		// Update is called once per frame
		void Update()
		{
			if (_killit <= 0)
				Die();
			transform.position = Vector3.MoveTowards(transform.position,
				new Vector3(_targ.position.x, transform.position.y, _targ.position.z), _velocity * Time.deltaTime);
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.CompareTag("Base"))
				Die();
			if (other.gameObject.CompareTag("Bullet"))
				_killit -= 3;
		}

		void Die()
		{
			Destroy(gameObject);
		}
	}
}