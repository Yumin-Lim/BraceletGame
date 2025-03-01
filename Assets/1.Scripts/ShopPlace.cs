using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class ShopPlace : MonoBehaviour
{
   
    public GameObject shopPanel; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
             
        Vector2 screenPoint = Input.mousePosition;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        Collider2D[] cols= Physics2D.OverlapPointAll(worldPoint);

        for(int i=0;i<cols.Length;i++)
        {
            if(cols[i].tag == "StorePlace")
            {
                Debug.Log("Store is Cliked");
                   shopPanel.SetActive(true);

            }
        }

        }
        
       
    }

   

   

}
