using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] private List<PoolAble> _PoolList;

    private static PoolManager _instance = null;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Pool").GetComponent<PoolManager>();
            }
            return _instance;
        }
    }

    private GameObject _Item;

    private Dictionary<string, Pool<PoolAble>> _pools = new Dictionary<string, Pool<PoolAble>>();


    private void Awake()
    {
        foreach (PoolAble p in _PoolList)
        {
            CreatePool(p, 3);
        }
    }

    public void CreatePool(PoolAble prefab, int cnt = 5, bool b = false)
    {
        Pool<PoolAble> pool = new Pool<PoolAble>(prefab, transform, cnt);

        if (_pools.ContainsKey(prefab.gameObject.name) == false)
            _pools.Add(prefab.gameObject.name, pool);
        //if(b==true)
        //_PoolList.Add(prefab.gameObject.GetComponent<PoolAble>());
    }

    public PoolAble Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("���������");
            return null;
        }


        PoolAble item = _pools[prefabName].Pop();
        item.Reset();
        return item;
    }


    public void Push(PoolAble obj)
    {
        obj.transform.SetParent(this.transform);
        _pools[obj.name].Push(obj);
    }
    public void RemovePool(string prefabName)
    {
        if (_pools.ContainsKey(prefabName))
        {
            _pools.Remove(prefabName);
        }
        else
        {
            Debug.LogError("���������..");
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == prefabName)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}