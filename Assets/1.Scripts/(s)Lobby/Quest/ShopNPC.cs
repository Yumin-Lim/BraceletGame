using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    public static ShopNPC Instance;

    public QuestData[] questDatas;

    //퀘스트 종류
    //만들 이미지를

    void Awake()
    {
        Instance = this;
     
    }
    private void Start()
    {
        
    }

    private void makingQuest()
    {
        questDatas = new QuestData[10]; //현제 레벨에 맞게 사용할 수 있는 비즈만 담는다 
        //아직 넣은거 아니고 넣을 수 있는 공간을 설정한것이다 그니까 new 가 있어야 실제로 담은것이다 

        List<BeadsData> canBeads = new List<BeadsData>();
        for (int i = 0; i < BeadsManager.Instance.beadsDatas.Length; i++)
        {
            if (BeadsManager.Instance.beadsDatas[i].openLv <= User.Instance.userData.level)
            {
                canBeads.Add(BeadsManager.Instance.beadsDatas[i]);
            }
        }

        List<string> canBoardKeys = new List<string>();
        for (int i = 0; i < User.Instance.userData.userBoardData.Count; i++) //UserInstance 에서 접근 가능한건 component vs class 
        {
            if (User.Instance.userData.userBoardData[i].purchased)
            {
                canBoardKeys.Add(User.Instance.userData.userBoardData[i].boardKey);
            }
        }


        for (int i = 0; i < questDatas.Length; i++)
        {
            questDatas[i] = new QuestData(); //각각의 칸에다 shopQuest 객체 채우기라는뜻
            questDatas[i].boardKey = canBoardKeys[Random.Range(0, canBoardKeys.Count)]; //여기 문제 이다 보유중인 보드 중 하나다 
            BoardData boardData = BeadsBoardManager.Instance.GetBoardData(questDatas[i].boardKey);

            //배열의 크기설정 객체가 담긴건 아님 
            questDatas[i].beadsPlaceCorrects = new BeadsPlaceCorrect[boardData.placeCount]; 

            for (int j = 0; j < questDatas[i].beadsPlaceCorrects.Length; j++)
            {
                questDatas[i].beadsPlaceCorrects[j] = new BeadsPlaceCorrect();
                questDatas[i].beadsPlaceCorrects[j].index = j;
                questDatas[i].beadsPlaceCorrects[j].beadKey = canBeads[Random.Range(0, canBeads.Count)].key;
            }

        }
      

    }


    
}
