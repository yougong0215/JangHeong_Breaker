using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
namespace AI
{
    public class AIBatch : AISelectPos
    {
        protected override void Awake()
        {
            base.Awake();
            _mode = AIUnitMode.Batch;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
