using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Street : MonoBehaviour
{

    public StreetType streetType;
    public GameObject mainCanvas;



    public void StartStreet()
    {
        mainCanvas.gameObject.SetActive(true);
        CatMaker.Instance.StartStreet(streetType);  
    }
    public void EndStreet()
    {
        mainCanvas.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum StreetType
{
    Lobby,
    Cat,
    Shop,
    Furniture
}