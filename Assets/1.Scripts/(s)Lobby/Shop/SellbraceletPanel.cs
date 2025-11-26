using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Data.Common;
using System.Data;
using UnityEditor.Rendering;
using System;
public class SellbraceletPanel : MonoBehaviour
{


  public Image thumImage;
  public static SellbraceletPanel Instance;
  public UserBracelet userBracelet;

  public void Awake()
  {
    Instance = this;





  }

  public void SetBracelet(UserBracelet userBracelet)
  {


    this.userBracelet = userBracelet;
    thumImage.sprite = userBracelet.GetBraceletThum();
  }

  public void sellButton()
  {

    Debug.Log("팔렸습니다.");


    User.Instance.SubBracelet(userBracelet);
    User.Instance.AddCoin(userBracelet.price);
    User.Instance.AddExp(2);

    BraceletData braceletData = BraceletManager.Instance.GetBraceletData(userBracelet.key);

    Destroy(thumImage.sprite); //팔았으니까 캡쳐 이미지 지우기
    Capture.Delete(userBracelet.key);  //파일도 지우기 



    gameObject.SetActive(false);

  }



  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  internal void SetBracelet(string questKey)
  {
    throw new NotImplementedException();
  }
  //멤버변수와 함수 갯수 
}
