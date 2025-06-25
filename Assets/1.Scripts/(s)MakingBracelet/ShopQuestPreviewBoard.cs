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
        Debug.Log("ShopQuestPreviewBoard UpdatePreviewBoard() 1");

        if (User.Instance.userData.userQuestList == null)
        {

            return;
        }
        Debug.Log("ShopQuestPreviewBoard UpdatePreviewBoard() 2");
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
            Debug.Log("ShopQuestPreviewBoard UpdatePreviewBoard() 3");
            ShowAnswer(curPreviewBoard, curradsBoardData.beadsPlaceCorrects);
        }

    }
    //이전에 썼던 비즈를 삭제를 혹은 비활성화를 해서 새로 다시 그려야 한다.
    //이전에 썼던 비즈들을 접근 할 수 있게 만들어주기 -> 리스트 

    public List<Beads> beadsList = new List<Beads>(); //오브젝트풀링 적용하면 좋겟다

    void ShowAnswer(BeadsBoard board, BeadsPlaceCorrect[] corrects) //카메라로 찍히는 구슬들이 배치되는 부분
    {
        for (int i = 0; i < beadsList.Count; i++)
        {
            Destroy(beadsList[i].gameObject);

        }
        beadsList.Clear(); //디스트로이 한다고 완전히 사라지는게 아니라 빈자리들이 있는것
        //클리어를 해야 아무것도 없어진다.
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
            beadsList.Add(beads);
        }
    }
}
