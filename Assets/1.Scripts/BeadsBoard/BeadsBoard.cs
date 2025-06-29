using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BeadsBoard : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static BeadsBoard Instance;
    public BeadsPlace[] beadsPlaces;
    public string key;
    public int order;

    private void Awake()
    {
        Instance = this;
        beadsPlaces = GetComponentsInChildren<BeadsPlace>();
         //beadsBoard 에 있는 하위의 것들 가져오려고 
      
         
    }


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class BeadsBoardData
{
    public string boardKey;
}
