using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menurecord : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuorder;
    public int count = 0;
    // Start is called before the first frame update
    public void recordmenu()
    {
        count = 1;
        menu.SetActive(false);
        menuorder.SetActive(false);

    }
}
