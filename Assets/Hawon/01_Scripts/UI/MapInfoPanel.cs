using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MapInfoPanel : MonoBehaviour
{
    [SerializeField] private float startPosY;

    TextMeshProUGUI nameText;
    TextMeshProUGUI infoText;
    private void Awake()
    {
        nameText = transform.Find("MapInfoPanel").transform.Find("MapNameText").GetComponent<TextMeshProUGUI>();
        infoText = transform.Find("MapInfoPanel").transform.Find("MapInfoText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        this.transform.localPosition = new Vector3(0, -970, 0);
    }

    public void OnPanel(MapSO mapData)
    {
        nameText.SetText(mapData.mapName);
        infoText.SetText(mapData.mapInfo);

        this.transform.DOLocalMoveY(0, 0.5f);
    }

    public void AttackDecision()
    {

    }    
    public void BackDecision()
    {
        this.transform.DOLocalMoveY(startPosY, 0.5f);
    }
}
