using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackBtn : MonoBehaviour
{

  public GameObject shopPannel;
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
    SceneManager.LoadScene("Lobby");


  }

  public void ShopPannelCloseButton()
  {
    shopPannel.SetActive(false);
  }
}
