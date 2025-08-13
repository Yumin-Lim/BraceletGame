using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraceletManager : MonoBehaviour
{
   public static BraceletManager Instance;
   
    // Start is called before the first frame update
   
   void Awake()
   {
    DontDestroyOnLoad(gameObject);
    Instance =this;
   }
   
    public BraceletData[] braceletDatas;
    
    
    public BraceletData GetBraceletData(string key)
    {
         for(int i = 0; i <  braceletDatas.Length; i++)   
       {
        if(braceletDatas[i].key== key)
        {
            return braceletDatas[i];
        }
        
       }

       return null;
       
    }

}