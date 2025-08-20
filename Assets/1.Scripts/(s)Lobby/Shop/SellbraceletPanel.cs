using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Data.Common;
using System.Data;
using UnityEditor.Rendering;
public class SellbraceletPanel : MonoBehaviour
{


  public Image thumImage;


  public int maxBraceletCount; //보유한 팔찌 갯수
  public int currentSellCount; //판매할 갯수 
  public UserBracelet userBracelet;
  public void SetBracelet(UserBracelet userBracelet)
  {
    this.userBracelet = userBracelet;
  }

  public void sellButton()
  {

    Debug.Log("팔렸습니다.");
  
  //  UserBracelet userBracelet = User.Instance.GetUserBracelet(userBracelet.key);


    //User.Instance.GetUserBracelet(braceletKey);
    // userBracelet.count -= currentSellCount;
    User.Instance.SubBracelet(userBracelet);

    BraceletData braceletData = BraceletManager.Instance.GetBraceletData(userBracelet.key);


      User.Instance.AddCoin(braceletData.price);
    
    //이거 왜 오류? 이거한다고 왜 왜 지 아
    //판매 상저 닫을대? 
    //destroy 하지 말고 그냥 비활성화 ->왜냐면 

    gameObject.SetActive(false);

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
