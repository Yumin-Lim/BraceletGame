using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class ShopQuestPreviewBoard : MonoBehaviour //퀘스트 미리보기를 처리하는 클래스이다 
{
    public static ShopQuestPreviewBoard Instance; //Instace 화 시켰다

 
    public QuestData curradsBoardData = new QuestData();
    public BeadsBoard[] beadsBoards; //인스펙터에서 모든 비즈 보드를 채원 넣었음 이미 
 
    void Awake()
    {
        Instance = this;
    }


    public void UpdatePreviewBoard()
    {

        if (User.Instance.userData.userQuestList == null)
        {

            return;
        }

        BeadsBoard curPreviewBoard = null;

        for (int i = 0; i < beadsBoards.Length; i++)
        {
            bool isMatch = beadsBoards[i].key == curradsBoardData.boardKey;
            beadsBoards[i].gameObject.SetActive(isMatch);

            if (isMatch)
            {
                curPreviewBoard = beadsBoards[i];
            }
        }


        if (curPreviewBoard != null)
        {
            ShowAnswer(curPreviewBoard, curradsBoardData.beadsPlaceCorrects);
        }
    
    }

    void ShowAnswer(BeadsBoard board, BeadsPlaceCorrect[] corrects)
    {
        BeadsPlace[] places = board.beadsPlaces;

        for (int i = 0; i < corrects.Length; i++)
        {
            places[i].SetBeads(null);
            BeadsPlaceCorrect correct = corrects[i];
            BeadsPlace place = places[correct.index];

            if (place.beads != null)
                continue;

            Beads beads = MakingBraceletManager.Instance.GetBeads();
            beads.SetBeads(correct.beadKey);
            beads.transform.position = place.transform.position;
            place.SetBeads(beads);
        }
    }
}
