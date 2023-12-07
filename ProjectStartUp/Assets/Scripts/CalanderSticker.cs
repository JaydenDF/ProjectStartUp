using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalanderSticker : MonoBehaviour
{
    [SerializeField] GameObject stickerHolder;
    [SerializeField] Sprite stickerSprite;
    public void PlaceSticker()
    {
        stickerHolder.SetActive(true);
        stickerHolder.GetComponent<Image>().sprite = stickerSprite;
    }
}
