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
        shopQuests = new ShopQuest[10]; //현제 레벨에 맞게 사용할 수 있는 비즈만 담는다 

        List<BeadsData> canBeads = new List<BeadsData>();
        for (int i = 0; i < BeadsManager.Instance.beadsDatas.Length; i++)
        {
            if (BeadsManager.Instance.beadsDatas[i].openLv <= User.Instance.userData.level)
            {
                canBeads.Add(BeadsManager.Instance.beadsDatas[i]);
            }
        }


        for (int i = 0; i < shopQuests.Length; i++)
        {
            shopQuests[i] = new ShopQuest();
            shopQuests[i].boardKey = "A";
            BoardData boardData = BeadsBoardManager.Instance.GetBoardData(shopQuests[i].boardKey);

            //배열의 크기설정 객체가 담긴건 아님 
            shopQuests[i].beadsPlaceCorrects = new BeadsPlaceCorrect[boardData.placeCount];

            for (int j = 0; j < shopQuests[i].beadsPlaceCorrects.Length; j++)
            {
                shopQuests[i].beadsPlaceCorrects[j] = new BeadsPlaceCorrect();
                shopQuests[i].beadsPlaceCorrects[j].index = j;
                shopQuests[i].beadsPlaceCorrects[j].beadKey = canBeads[Random.Range(0, canBeads.Count)].key;
            }

        }

        StartQuest();
    }

    public ShopQuest curShopQuest;
    public void StartQuest()
    {
        //씬 전환이 되어도 지워지지 않  는 곳에 넣어줌 ㄴ
        User.Instance.shopQuest = shopQuests[Random.Range(0, shopQuests.Length)];
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