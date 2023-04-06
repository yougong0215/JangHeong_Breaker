using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{


    public abstract class AISelectPos : MonoBehaviour
    {
        [SerializeField] AIUnitMode _mode;


        public AIUnitMode Mode => _mode;

        public void Batching(GameObject obj)
        {

        }

    }
}