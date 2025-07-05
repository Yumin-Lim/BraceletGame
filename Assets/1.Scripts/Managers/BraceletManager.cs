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
    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class BraceletData //객체를 만들기 위한 설계도 : class

{
    public int price;
    public string key;
    public string name;
    public string des;
    public Concept concept; //이렇게 하면 아래 에서 있는 것들을 선택 가능
    public Sprite thum;
    public BraceletNeed[] braceletNeeds;
}
[System.Serializable]
public class BraceletNeed
{
    public string beadsKey;
    public float rate; 
    public int count;
}

