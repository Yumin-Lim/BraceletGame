using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
public class BraceletQuestBoard : MonoBehaviour
{

    public Image thumImage;
    //   public TMP_Text titleText;

    public QuestData questForBraceletBoard;
    // Start is called before the first frame update

    public void OnclickedButton()
    {


        if (ShopQuestPreviewBoard.Instance == null)
        {
            Debug.LogError("ShopQuestPreviewBoard.Instance가 null");
            Debug.LogError("beadsPlaceCorrects가 null입니다!");
            return;
        }
        else
        {



            ShopQuestPreviewBoard.Instance.curradsBoardData = questForBraceletBoard;

            ShopQuestPreviewBoard.Instance.UpdatePreviewBoard();







        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
