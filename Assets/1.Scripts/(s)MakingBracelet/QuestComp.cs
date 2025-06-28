using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComp : MonoBehaviour
{
    // 상자에 넣는 모션 있으면 좋겠음 GIF

    public QuestData questdata;
    public static QuestComp Instance;
    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void data(QuestData questData)
    {
        this.questdata =questData;
    }
    public void onClikedBtn()
    {
        User.Instance.userData.userQuestList.Remove(questdata);
    }
}
