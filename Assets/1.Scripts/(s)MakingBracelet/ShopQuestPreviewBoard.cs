using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


   public class ShopQuestPreviewBoard : MonoBehaviour
{
    public static ShopQuestPreviewBoard Instance;

    public BeadsBoard[] beadsBoards;

    void Awake()
    {
        Instance = this;
    }


   public void UpdatePreviewBoard()
{
    Debug.Log("🟢 UpdatePreviewBoard 호출됨!");

    if (User.Instance.shopQuest == null)
    {
        Debug.LogError("❌ User의 shopQuest가 null입니다!");
        return;
    }

    // 나머지 로직...

        BeadsBoard curPreviewBoard = null;

        for (int i = 0; i < beadsBoards.Length; i++)
        {
            bool isMatch = beadsBoards[i].key == User.Instance.shopQuest.boardKey;
            beadsBoards[i].gameObject.SetActive(isMatch);

            if (isMatch)
            {
                curPreviewBoard = beadsBoards[i];
            }
        }

        if (curPreviewBoard != null)
        {
            ShowAnswer(curPreviewBoard, User.Instance.shopQuest.beadsPlaceCorrects);
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
