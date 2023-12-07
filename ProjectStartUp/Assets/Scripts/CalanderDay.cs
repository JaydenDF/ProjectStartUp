using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalanderDay : MonoBehaviour
{
    [SerializeField] CalanderManager calanderManager;
    [SerializeField] GameObject stickerTab;

    public void SelectDay()
    {
        calanderManager.dayIsSelectd = true;
        stickerTab.SetActive(true);
    }
}
