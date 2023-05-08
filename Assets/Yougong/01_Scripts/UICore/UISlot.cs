using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    GameObject obj;
    public void Triggerd()
    {
        UISlotManager.Instance.SoltUI = this;
    }

    public void Out()
    {
        UISlotManager.Instance.SoltUI = null;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
            return;


        if (UISlotManager.Instance.SoltUI == this)
        {
            if(obj != null)
            {
                Destroy(obj);
            }

            obj = UISlotManager.Instance.UnitUI.gameObject;
            obj.transform.parent = transform.parent;
            obj.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        }
    }
}
