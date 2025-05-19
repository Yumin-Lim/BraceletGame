using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraceletPlaceSys_2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Camera mainCamera;
    public GameObject[] BraceletPlaces;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
 
    public BraceletPlaceSys_2()
    {
        for(int i = 0; i <  BraceletPlaces.Length; i++) 
        {
            if(BraceletPlaces[i].gameObject.transform.position ==mainCamera.transform.position )
            {
                BraceletPlaces[i].gameObject.SetActive(true);
            }
             BraceletPlaces[i].gameObject.SetActive(false);
        }
      
    }
}
