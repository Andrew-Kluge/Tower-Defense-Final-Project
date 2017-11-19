using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class BulletManager : MonoBehaviour
    {

        // Use this for initialization

        /// <summary>
        /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
        /// </summary>
        private Object _bullet;

        public void Start()
        {
            _bullet = Resources.Load("Bullet");
        }

        public void ForceSpawn(GameObject target)
        {
            GameObject bullet = (GameObject)Object.Instantiate(_bullet, transform.position, transform.rotation);
            //bullet.transform.SetParent(gameObject.transform);
            bullet.GetComponent<Bullets>().Initialize(target);
        }
    }
}


