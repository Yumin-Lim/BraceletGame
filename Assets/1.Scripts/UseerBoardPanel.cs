using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Data.Common;
using System.Data;
using UnityEngine.SceneManagement;
public class UseerBoardPanel : MonoBehaviour
{
    // Start is called before the first frame update

    public Image thumImage;

    public string boardKey;
    public TMP_Text name;

    public void SetBoard(string boardKey)
    {
        this.boardKey = boardKey;
        BoardData data = BeadsBoardManager.Instance.GetBoardData(boardKey);
        thumImage.sprite = data.thum;

        name.text = data.name;



    }



    void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnclikedButton()
    {

        // BraceletPlaceSys board = FindAnyObjectByType<BraceletPlaceSys>();

        User.Instance.selectedBoardKey = boardKey;
        Debug.Log("보드키 유저에게 할당" + boardKey);


        SceneManager.LoadScene("MakingBracelet");
    }
}
