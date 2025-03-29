using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    public ShopQuest[] shopQuests;

    //퀘스트 종류
    //만들 이미지를 
    private void Start()
    {
        shopQuests = new ShopQuest[10];

        List<BeadsData> canBeads = new List<BeadsData>();
        for(int i =0;i< BeadsManager.Instance.beadsDatas.Length; i++)
        {
            if(BeadsManager.Instance.beadsDatas[i].openLv <= User.Instance.userData.level)
            {
                canBeads.Add(BeadsManager.Instance.beadsDatas[i]);
            }
        }


        for(int i =0;i< shopQuests.Length; i++)
        {
            shopQuests[i] = new ShopQuest();
            shopQuests[i].boardKey = "a";
            BoardData boardData = BeadsBoardManager.Instance.GetBoardData(shopQuests[i].boardKey);

            shopQuests[i].beadsPlaceCorrects = new BeadsPlaceCorrect[boardData.placeCount];

            for(int j =0;j< shopQuests[i].beadsPlaceCorrects.Length; j++)
            {
                shopQuests[i].beadsPlaceCorrects[j].index = j;
                shopQuests[i].beadsPlaceCorrects[j].beadKey = canBeads[Random.Range(0, canBeads.Count)].key;
            }
            
        }

        StartQuest();
    }

    public ShopQuest curShopQuest;
    public void StartQuest()
    {
        curShopQuest = shopQuests[Random.Range(0, shopQuests.Length)];
    }
}

[System.Serializable]
public class ShopQuest
{
    public string boardKey;
    public BeadsPlaceCorrect[] beadsPlaceCorrects;
}

[System.Serializable]
public class BeadsPlaceCorrect
{
    public int index;
    public string beadKey;
}