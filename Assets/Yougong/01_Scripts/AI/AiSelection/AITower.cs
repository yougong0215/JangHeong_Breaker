using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{

    public class AITower : AISelectPos
    {
        protected override void Awake()
        {
            base.Awake();
            _mode = AIUnitMode.BatchTower;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}