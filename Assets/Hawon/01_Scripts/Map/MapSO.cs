using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Map/MapData")]
public class MapSO : ScriptableObject
{
    public string mapName;
    public string mapInfo;

    public GameObject MapPrefab;
    public Vector3 MapPos;
    public Vector3 movePos;
    public Map map;
}
