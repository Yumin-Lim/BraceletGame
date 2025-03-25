using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BraceletPlaceSys : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject firstPlacePosition;
    public GameObject lastPlacePosition;

    public GameObject leftButton;
    public GameObject rightButton;

    public BeadsBoard[] beadsBoards;


    public string boardKey;
    //이 보드키가 버튼 뉼렸을때 할당을 받아야 하고 그 할당받은 보드키랑 보드 리스트랑 비교해서 같은것만 

    //뭔가 현재 보드 
    public int currentBoardIdx; //현재 보여지는 보드인뎃그
    






    void Start()
    {
        UpdateBraceletPlaces();
    }
    
    public void SetBoardKeSys(string boardKey)
    {
        this.boardKey = boardKey;
    }
    
    private void Awake()
    {
        BeadsBoard[] bBoard = FindObjectsOfType<BeadsBoard>(true);//비활오하 되어있는것도 찾ㅡ다. 
        beadsBoards=bBoard.OrderBy(e => e.order).ToArray();
        currentBoardIdx = 0;
    }


    void UpdateBraceletPlaces()
    {
        leftButton.SetActive(mainCamera.transform.position != firstPlacePosition.transform.position);
        rightButton.SetActive(mainCamera.transform.position != lastPlacePosition.transform.position);

        //현재 보드가 1번째 보드일떄??


        for (int i = 0; i < beadsBoards.Length; i++)
        {
            if (currentBoardIdx == i)
            {
                beadsBoards[i].gameObject.SetActive(true);
                beadsBoards[i].StartBeadsBoard();
            }
            else
            {
                beadsBoards[i].gameObject.SetActive(false);
            }
        }
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        if (currentBoardIdx == beadsBoards.Length - 1)
        {
            rightButton.SetActive(false);
        }
        if (currentBoardIdx == 0)
        {
            leftButton.SetActive(false);
        }
    }

    public void OnclickedLeftButton()
    {
        currentBoardIdx--;
        UpdateBraceletPlaces();

    }

    public void OnclickedRightButton()
    {
        currentBoardIdx++;
        UpdateBraceletPlaces(); // 패널 상태 업데이트

    }
}
