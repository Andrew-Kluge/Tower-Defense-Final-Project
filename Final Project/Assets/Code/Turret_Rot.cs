using UnityEngine;
using System.Collections;
 
public class Turret_Rot : MonoBehaviour {
	public float speed = 25.0f;
 
	public GameObject m_target = null;
	public Vector3 m_lastKnownPosition = Vector3.zero;
	public Quaternion m_lookAtRotation;

	private const float FireCooldown = 1f;
	private float _lastfire;
	public BulletManager _bman;

	void Start()
	{
		_bman = GameObject.FindGameObjectWithTag("Bullet_Spawn").GetComponent<BulletManager>();
		_lastfire = 0f;
	}
	// Update is called once per frame
	void Update ()
	{
		GameObject[] Oppons = GameObject.FindGameObjectsWithTag("Enemy");
		if (Oppons.Length > 0)
		{
			GameObject closest = Oppons[0];
			float currDist = Vector3.Distance(transform.position, closest.transform.position);
			foreach (var oppon in Oppons)
				if (Vector3.Distance(oppon.transform.position, transform.position) < currDist)
				{
					closest = oppon;
					currDist = Vector3.Distance(oppon.transform.position, transform.position);
				}
			m_target = closest;
			
			if(m_target){
				if(m_lastKnownPosition != m_target.transform.position){
					m_lastKnownPosition = m_target.transform.position;
					m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - new Vector3(0f,transform.position.y,0f));
				}
 
				if(transform.rotation != m_lookAtRotation){
					transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
				}
			}
			
			float time = Time.time;
			if (time >= _lastfire + FireCooldown)
			{
				_lastfire = time;
				_bman.ForceSpawn(m_target);
			}
		}
	}
 
	public void SetTarget(GameObject target){
		m_target = target;
	}
}