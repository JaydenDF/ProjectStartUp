using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeItem : MonoBehaviour
{
    [SerializeField] Button associatedMascot;
    [SerializeField] GameObject checkMark;
    [SerializeField] private TMP_Text collectedAmount;
    [SerializeField] Sprite wardrobeItemImage;
    [SerializeField] Sprite mascotSprite;

    int completionAmount = 6;
    public int currentAmount;

    public bool isCompleted = false;
    public bool isActive = false;
    public bool canBeActivated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount != completionAmount)
        {
            collectedAmount.text = currentAmount + "/" + completionAmount;
        }

        if (currentAmount == completionAmount)
        {
            isCompleted = true;
            collectedAmount.text = "";
        }

        if (isActive)
        {

        }
    }

    public void ActivateOrDeactivate()
    {
        if (!isActive && isCompleted)
        {
            ActivateWardrobeItem();
        }
        else if (isActive)
        {
            DeactivateWardrobeItem();
        }
    }

    public void ActivateWardrobeItem()
    {
        associatedMascot.GetComponent<Image>().sprite = wardrobeItemImage;
        isActive = true;
        canBeActivated = false;
        checkMark.SetActive(true);
    }

    public void DeactivateWardrobeItem()
    {
        isActive = false;
        canBeActivated = true;
        associatedMascot.GetComponent<Image>().sprite = mascotSprite;
        checkMark.SetActive(false);
    }
}
