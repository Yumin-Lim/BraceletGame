using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//뭐든지 유저가 가진 정보면 유저에 있고 비즈에대한 그 비즈 자체에 대한 정보는 비즈 매니저에 있지 ㅡㅡ





public class BeadsManager : MonoBehaviour
{
     
     
      public static BeadsManager Instance;
     
     public BeadsData[] beadsDatas; //array 사용했다

 public void Awake()
    {
        DontDestroyOnLoad(gameObject);//씬 ㅈ ㅓㄴ환되어도 제거되지 않는다 
        
        
        Instance = this;
    }





    public BeadsData GetBeadsData(string key)
    {
        for (int i=0;i<beadsDatas.Length;i++)
            {
                if(beadsDatas[i].key ==  key)
                {
                return beadsDatas[i];
                
                }
            }
            return null;

    }




}
[System.Serializable]
public class BeadsData //객체를 만들기 위한 설계도 : class

{
    public int price;
    public string key;
    public string name;
    public string des;
    public Concept concept; //이렇게 하면 아래 에서 있는 것들을 선택 가능
    public Sprite thum;
    public int openLv;

}
public enum Concept
{
    Basic,
    Gothic,
    Cute,
}
 