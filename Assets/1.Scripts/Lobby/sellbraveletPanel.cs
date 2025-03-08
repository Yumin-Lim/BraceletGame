using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Data.Common;
using System.Data;
public class sellbraveletPanel : MonoBehaviour
{
 
  
  public Image thumImage;


  public int maxBraceletCount; //보유한 팔찌 갯수
  public int currentSellCount; //판매할 갯수 

  public string key;
  public void SetBracelet(string Key)
  {
    this.key = Key;
    BraceletData data = BraceletManager.Instance.GetBraceletData(Key);
    thumImage.sprite = data.thum;
    UserBracelet userBracelet = User.Instance.GetUserBracelet(Key);
   
    maxBraceletCount = userBracelet.count;
    currentSellCount = 1;


  }

  public void sellButton()
  {

      Debug.Log("팔렸습니다.");
      Debug.Log(key);
      UserBracelet userBracelet = User.Instance.GetUserBracelet(key);


      //User.Instance.GetUserBracelet(braceletKey);
      // userBracelet.count -= currentSellCount;
      User.Instance.SubBracelet(key, currentSellCount);

      BraceletData braceletData = BraceletManager.Instance.GetBraceletData(key);
      User.Instance.AddCoin(braceletData.price);
    
     

  }



  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  //멤버변수와 함수 갯수 
}
