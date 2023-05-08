using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlotManager : MonoBehaviour
{
    public static UISlotManager Instance;

    public UIDragAndDrop UnitUI;
    public UISlot SoltUI;


    private void Awake()
    {
        Instance = this;
    }

    public void NullUIS()
    {
        UnitUI = null;
        SoltUI = null;
    }

}
