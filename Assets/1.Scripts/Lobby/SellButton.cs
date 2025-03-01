using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    
    public GameObject sellCanvas; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickedButton()
    {
        sellCanvas.SetActive(true);
        Debug.Log("sellbutton");
     
       }
}
