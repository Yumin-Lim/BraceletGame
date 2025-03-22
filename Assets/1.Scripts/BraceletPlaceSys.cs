using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraceletPlaceSys : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject firstPlacePosition;
    public GameObject lastPlacePosition;

    public GameObject leftButton;
    public GameObject rightButton;

    public GameObject[] BraceletPlaces;

    void Start()
    {
        UpdateButtons(); 
        UpdateBraceletPlaces(); 
    }

    void UpdateButtons()
    {

        leftButton.SetActive(mainCamera.transform.position != firstPlacePosition.transform.position);
        rightButton.SetActive(mainCamera.transform.position != lastPlacePosition.transform.position);
    }

    void UpdateBraceletPlaces()
    {
        for (int i = 0; i < BraceletPlaces.Length; i++)
        {
            if (Vector3.Distance(BraceletPlaces[i].transform.position, mainCamera.transform.position) < 0.1f)
            {
                BraceletPlaces[i].SetActive(true);
            }
            else
            {
                BraceletPlaces[i].SetActive(false);
            }
        }
    }

    public void OnclickedLeftButton()
    {
        if (mainCamera.transform.position != firstPlacePosition.transform.position)
        {
            mainCamera.transform.position += new Vector3(-10, 0, 0);
            UpdateButtons();  
            UpdateBraceletPlaces(); 
        }
    }

    public void OnclickedRightButton()
    {
        if (mainCamera.transform.position != lastPlacePosition.transform.position)
        {
            mainCamera.transform.position += new Vector3(10, 0, 0);
            UpdateButtons(); 
            UpdateBraceletPlaces(); // 패널 상태 업데이트
        }
    }
}
