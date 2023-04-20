using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class AIArea : AISelectPos
    {
        protected override void Awake()
        {
            base.Awake();
            _mode = AIUnitMode.AreaUnit;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
