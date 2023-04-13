using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{


    public abstract class AISelectPos : MonoBehaviour
    {
        [SerializeField] protected AIUnitMode _mode;

        [SerializeField] GameObject obj;

        protected virtual void Awake()
        {
            if(obj != null)
            {
                obj = Instantiate(obj, transform);
                obj.transform.position = transform.position;
            }
        }

        public bool ReturnObj()
        {
            return obj == null;
        }


        public AIUnitMode Mode => _mode;

        public void Batching(GameObject In)
        {
            this.obj = In;
            obj.transform.parent = transform;
            obj.transform.position = transform.position;
            StartCoroutine(Batched());
        }

        IEnumerator Batched()
        {
            yield return new WaitUntil(() => ReturnObj());

            Debug.Log($"{gameObject.name} 배치 가능");



        }

    }
}