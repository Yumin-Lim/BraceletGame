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
        beadsDatas = Resources.LoadAll<BeadsData>("BeadsData");

        Instance = this;
    }





    public BeadsData GetBeadsData(string key)
    {
        for (int i = 0; i < beadsDatas.Length; i++)
        {
            if (beadsDatas[i].key == key)
            {
                Debug.Log("겟비즈데이터" + beadsDatas[i]);
                return beadsDatas[i];
               

            }
        }
        return null;

    }




}


public enum Concept
{
    Basic,
    Gothic,
    Cute,
}
