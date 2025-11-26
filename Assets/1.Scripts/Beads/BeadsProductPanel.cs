using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //이미지 컴포넌트 위해서 
using TMPro;




public class BeadsProductPanel : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Image thumImage;
    public string beadsKey;
    public TMP_Text concept;



    public BeadsData beadsData;

    // Start is called before the first frame update






    void Start()
    {



        BeadsManager mgr = FindObjectOfType<BeadsManager>();
        beadsData = mgr.GetBeadsData(beadsKey);

        nameText.text = beadsData.name;
        priceText.text = beadsData.price.ToString();
        thumImage.sprite = beadsData.thum;
        concept.text = beadsData.concept.ToString();





    }

    public void OnClickedPurchaseButton()
    {
        if (beadsData.concept == Concept.Fairy)
        {
            Debug.Log("Fairy Beads Purchased");
            User user = User.Instance;
            if (user.userData.userTicketDatas.Count< beadsData.price)
            {
                Debug.Log("no Tickets");
                return;
            }
            user.SubTicket(beadsData.price);
            user.AddBeads(beadsKey, 10);

        }
        else
        {
            //User user = FindObjectOfType<User>(); //이거 너무 무거워서 
            User user = User.Instance;
            if (user.userData.coin < beadsData.price)
            {
                Debug.Log("no money");
                return;
            }
            user.AddCoin(-beadsData.price);
            user.AddBeads(beadsKey, 10); //사용자 구매시 얻게 되는 비즈 1개에서 10개로 수정 

        }



    }







    // Update is called once per frame
    void Update()
    {

    }
}
