using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum Map
{
    hentaipark,
    treetomb,
    castle,
    battleTower,
    agentPlace
}

public class MapSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private List<MapSO> mapList = new List<MapSO>();
    [SerializeField] private Map _currentMapInfo;
    bool canMove = true;
    MapInfoPanel _mapInfopanel;
    CameraMove _cameraMove;

    public bool canClick = true;
    private void Awake()
    {
        _mapInfopanel = GameObject.Find("MapContent").GetComponent<MapInfoPanel>();
        _cameraMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
    }

    private void Update()
    {
        MapClick();
    }

    private void MapClick()
    {
        if (Input.GetMouseButtonDown(0) && !_cameraMove.isAlt && canClick)
        {
            Ray worldPointRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(worldPointRay, out hit, 1000f) && hit.collider.gameObject.CompareTag("Map"))
            {
                for(int i = 0; i < mapList.Count; i++)
                {
                    if(hit.collider.gameObject.name == mapList[i].MapPrefab.name)
                    {
                        canClick = false;
                        _currentMapInfo = mapList[i].map;
                        SetMapPos(mapList[i].MapPos, mapList[i].movePos, i);
                        
                        break;
                    }
                }
            }
        }
    }

    void SetMapPos(Vector3 pos, Vector3 pPos, int num)
    {
        if(canMove)
        {
            canMove = false;
            Camera.main.transform.DOMove(pos, 1);
            _player.transform.DOMove(pPos, 1.5f);
        }
        StartCoroutine(Delay(num));   
    }

    IEnumerator Delay(int num)
    {
        yield return new WaitForSeconds(1);
        _mapInfopanel.OnPanel(mapList[num]);
        canMove = true;
    }

    public void CanClick()
    {
        canClick = true;
    }
}

