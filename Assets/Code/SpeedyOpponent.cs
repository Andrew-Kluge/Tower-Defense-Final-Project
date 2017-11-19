using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class SpeedyOpponent : Opponent
    {

        // Use this for initialization
        void Start()
        {
            _killit = 5;
            _targ = GameObject.FindGameObjectWithTag("Base").transform;
            _velocity = 2.0f;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

