using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    public GameObject Panel;
    public void OpenShop()
    {
        if(Panel != null && !Panel.activeSelf) Panel.SetActive(true);
        else Panel.SetActive(false);
    }
    
}
