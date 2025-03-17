using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPrefab : MonoBehaviour
{
    
    public GameObject catPrefab;
    public string CatKey;


    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeCat(string catKey)
    {
        
        
        if(catKey == CatKey)
        {
             GameObject clonedPrefab = Instantiate(catPrefab);
        }
    }
}

