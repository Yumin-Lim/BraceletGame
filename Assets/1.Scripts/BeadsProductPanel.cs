using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //이미지 컴포넌트 위해서 
using TMPro;




public class BeadsProductPanel : MonoBehaviour
{
   
     public static BeadsProductPanel Instance;
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Image thumImage;
    public TMP_Text desText;
    public string beadsKey;



    public BeadsData beadsData;
    // Start is called before the first frame update


     
  


  void Awake() // 싱글톤 하려면 위에 인스턴스 추가 플러스 이것도 필수!
  {
    if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 제거
            return;
        }
  }
    void Start()
    {
    
        //BeadsData beadsData = GetComponent<BeadsManager>();이거는 <> 안에 컴포넌트가 있어야 함 있는중에서 찾는것
        BeadsManager mgr = FindObjectOfType<BeadsManager>(); //사용지양 upadate 이런데서 쓰지 말아야함 무거워서 
        beadsData = mgr.GetBeadsData(beadsKey); 
       
        nameText.text = beadsData.name;
        priceText.text = beadsData.price.ToString(); //숫자를 문자열로 바꾸는 함수 
        thumImage.sprite = beadsData.thum;
        //desText.text = beadsData.des;





    }

    public void OnClickedPurchaseButton()
    {
        //User user = FindObjectOfType<User>(); //이거 너무 무거워서 
        User user = User.Instance;
        if(user.coin < beadsData.price)
        {
            Debug.Log("no money");
            return;
        }
        if(user.coin > beadsData.price)
        {
            user.coin -= beadsData.price;
        }
        user.AddCoin(-beadsData.price);
        user.AddBeads(beadsKey, 1);

      
    }







    // Update is called once per frame
    void Update()
    {
        
    }
}
