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
        //User user = FindObjectOfType<User>(); //이거 너무 무거워서 
        User user = User.Instance;
        if (user.userData.coin < beadsData.price)
        {
            Debug.Log("no money");
            return;
        }
        if (user.userData.coin > beadsData.price)
        {
            user.AddCoin(-beadsData.price);
        }
        user.AddCoin(-beadsData.price);
        user.AddBeads(beadsKey, 1);


    }







    // Update is called once per frame
    void Update()
    {

    }
}
