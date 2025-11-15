using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{
    public Street[] streets;
    public Camera mainCamera;



    public void Start()
    {
        //일단 다끄기 

        MoveTo(StreetType.Lobby);
    }





    public void MoveTo(StreetType type)
    {


        for (int i = 0; i < streets.Length; i++)
        {
            if (streets[i].streetType == type)
            {
                mainCamera.transform.position = streets[i].transform.position;
                streets[i].gameObject.SetActive(true);
                streets[i].StartStreet();




            }
            else
            {
                streets[i].EndStreet();
                streets[i].gameObject.SetActive(false);
            }

        }
    }



}
