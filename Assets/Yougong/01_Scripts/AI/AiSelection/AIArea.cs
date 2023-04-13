using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class AIArea : AISelectPos
    {
        private void Awake()
        {
            _mode = AIUnitMode.AreaUnit;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
