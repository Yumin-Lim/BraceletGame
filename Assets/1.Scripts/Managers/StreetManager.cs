using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class StreetManager : MonoBehaviour
{
    public Street[] streets;
    public Camera mainCamera;

 

    public void MoveTo(StreetType type)
    {
       
       
       for(int i=0; i<streets.Length; i++)
       {
            if (streets[i].streetType == type)
            {
                mainCamera.transform.position = streets[i].transform.position;
                streets[i].StartStreet();
                
        }
            else
            {
                streets[i].EndStreet();
            }
        
       } 
    }
    

    
}
