using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{


    public abstract class AISelectPos : MonoBehaviour
    {
        [SerializeField] protected AIUnitMode _mode;

        GameObject obj;

        public AIUnitMode Mode => _mode;

        public void Batching(GameObject In)
        {
            this.obj = In;
            obj.transform.parent = transform;
            obj.transform.position = transform.position;
        }

    }
}