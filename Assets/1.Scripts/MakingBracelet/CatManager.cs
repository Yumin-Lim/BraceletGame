using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static CatManager instance;
    public CatData[] catDatas;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    public CatData GetCatData(string catKey)
    {
        for (int i = 0; i < catDatas.Length; i++)
        {
            if (catDatas[i].catKey == catKey)
            {
                return catDatas[i];
            }
        }
        return null;
    }
}

[System.Serializable]
public class CatData
{
    public string name;
    public int price;
    public Sprite thum;
    public string catKey;
    public CatConcept concept;
    //public animation; //애니메이션 제어하는 이런거 없나??그래서 여기에 애니메이션 넣고 이럴 수 없나??

}

public enum CatConcept
{
    Normal,
    Special,
}