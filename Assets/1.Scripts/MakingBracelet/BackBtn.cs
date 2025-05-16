using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackBtn : MonoBehaviour
{

  public GameObject shopPannel;
  public GameObject shop1Pannel;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  public void OnClickedButton()
  {
    Debug.Log("backBtn onclicked");
    SoundManager.Instance.PlaySound(SoundType.Click);
  
    
    ReGettingBeads();
    SceneManager.LoadScene("Lobby");


  }
  public void ReGettingBeads()
  {

    MakingBraceletManager mgr = FindAnyObjectByType<MakingBraceletManager>();




    if (mgr.haveEmptyPlace == false)
    {
      Debug.Log("아직 다 안채워져서 비즈최수");

      User user = User.Instance;

      for (int i = 0; i < mgr.currentBeads.Count; i++)
      {
        
        
        user.AddBeads(mgr.currentBeads[i].beadsKey, 1);

      }
      // currentBeads 리스트 비우기

    }
    else
    {
      Debug.Log(" 비즈를 회수X.");
    }
  }


  public void ShopPannelCloseButton()
  {
    shopPannel.SetActive(false);
  }
  public void Shop1PannelCloseButton()
  {
    shop1Pannel.SetActive(false);
  }
}
