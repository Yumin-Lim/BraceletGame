using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class SelectBeadsPanel : MonoBehaviour
{


    public TMP_Text CountText;
    public Image[] thumImage;
    public string beadsKey;
    public UserBeads userBeads;

    // Start is called before the first frame update
  



    public void beadsPrefabDes()
    {

    }





    public void SetBeads(string beadsKey) //레드를 보여주는건지 블루를 보여주는건지 
    {
        this.beadsKey = beadsKey; //지금 이름이 똑같아서 내가 가진 멤버변수 비즈키 라고 확실히 알려줌 
        userBeads = User.Instance.GetUserBeads(beadsKey);
        CountText.text = userBeads.count.ToString();
        //thumImage.sprite = BeadsManager.Instance.GetBeadsData(beadsKey).thum;


        for (int i = 0; i < thumImage.Length; i++)
        {
            thumImage[i].sprite = BeadsManager.Instance.GetBeadsData(beadsKey).thum;
        }
        
       
        
        
        //왜냐면 각 패널당 키가 들어가 있으므로 그걸 가져오면 되지 않을까 
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update() //11/19
    {

        CountText.text = userBeads.count.ToString();
    }

    public void OnClickedSelectedBeads()
    {

        FindObjectOfType<MakingBraceletManager>().SelectedBeads(beadsKey);
    }



}


//내가 여기서 해야하는것 1. 내가 패널을 누르면 이 패널에 비즈의 정보를 가지고 온다 2.정보를 가지고 왔으면 MakingBraceletManager에 그 정보 연결해서 썸네일을 그걸 기반으로 바꾼다. 각 패널의 비즈 정보는 어디에 있지?-> 근데 문제는 비즈키이다 