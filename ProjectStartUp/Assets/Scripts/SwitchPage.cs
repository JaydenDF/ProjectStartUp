using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPage : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenNewPage(GameObject newPage)
    {
        newPage.SetActive(true);
    }

    public void CloseCurrentPage(GameObject currentPage)
    {
        currentPage.SetActive(false);
    }
}
