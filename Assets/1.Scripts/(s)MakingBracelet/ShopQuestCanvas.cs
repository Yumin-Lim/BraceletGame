using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopQuestCanvas : MonoBehaviour
{
   
     public static ShopQuestCanvas Instance;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
