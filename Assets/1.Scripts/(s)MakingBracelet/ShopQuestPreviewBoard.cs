using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopQuestPreviewBoard : MonoBehaviour
{
    public BeadsBoard[] beadsBoards;
    // Start is called before the first frame update
    void Start()
    {
        //무슨 처리가 필요한가요?
        BeadsBoard curPreviewBoard = null;
        for (int i = 0; i < beadsBoards.Length; i++)
        {
            if (beadsBoards[i].key == User.Instance.shopQuest.boardKey)
            {
                beadsBoards[i].gameObject.SetActive(true);
                curPreviewBoard = beadsBoards[i];
            }
            else
            {
                beadsBoards[i].gameObject.SetActive(false);
            }

             if (curPreviewBoard != null)
        {
            ShowAnswer(curPreviewBoard, User.Instance.shopQuest.beadsPlaceCorrects);
        }

        }
   


    }
    void ShowAnswer(BeadsBoard board, BeadsPlaceCorrect[] corrects)
    {
        BeadsPlace[] places = board.beadsPlaces;

        for (int i = 0; i < corrects.Length; i++)
        {
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
    


