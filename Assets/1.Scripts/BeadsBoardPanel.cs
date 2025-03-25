using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //이미지 컴포넌트 위해서 
using TMPro;


public class BeadsBoardPanel : MonoBehaviour
{
    // Start is called before the first frame update

    public string boardKey;
    public TMP_Text name;
    public TMP_Text price;
    public Image image;
    public TMP_Text concept;



    public BoardData boardDatas;

    void Start()
    {
        BeadsBoardManager mgr = FindObjectOfType<BeadsBoardManager>();
        boardDatas = mgr.GetBoardData(boardKey);

        name.text = boardDatas.name;
        price.text = boardDatas.price.ToString();
        image.sprite = boardDatas.thum;
        concept.text = boardDatas.concept.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnClickedPurchaseButton()
    {
        //User user = FindObjectOfType<User>(); //이거 너무 무거워서 
        User user = User.Instance;
        if (user.userData.coin < boardDatas.price)
        {
            Debug.Log("no money");
            return;
        }
        if (user.userData.coin > boardDatas.price)
        {
            user.userData.coin -= boardDatas.price;
        }
        user.AddCoin(-boardDatas.price);
        user.AddBoard(boardKey);

      UseerBoardPanel panel = FindAnyObjectByType<UseerBoardPanel>();




    }

}


