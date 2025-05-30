using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
public class BraceletQuestBoard : MonoBehaviour
{

      public Image thumImage;
       //   public TMP_Text titleText;
          
             public ShopQuest questForBraceletBoard;
    // Start is called before the first frame update

    public void OnclickedButton()
{
    Debug.Log("✅ 버튼 클릭됨!");
    User.Instance.shopQuest = questForBraceletBoard;

    Debug.Log($"🟡 User의 shopQuest.boardKey: {User.Instance.shopQuest.boardKey}");

    if (ShopQuestPreviewBoard.Instance == null)
    {
        Debug.LogError("❌ ShopQuestPreviewBoard.Instance가 null입니다!");
    }
    else
    {
        Debug.Log("✅ UpdatePreviewBoard 호출!");
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
