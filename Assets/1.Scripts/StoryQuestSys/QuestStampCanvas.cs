using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class QuestStampCanvas : MonoBehaviour
{
    public static QuestStampCanvas Instance;
    public int questStempCount;


    public PawStamp[] questStamp = new PawStamp[10];

    private void Awake()
    {
        questStamp = GetComponentsInChildren<PawStamp>();
        for (int i = 0; i < questStamp.Length; i++)
        {
            questStamp[i].gameObject.SetActive(false);
        }
        Instance = this;
    }
    public void QuestStempAdd()
    {
        questStempCount++;
        questStamp[questStempCount - 1].gameObject.SetActive(true);
        //카운트의 인덱스의 스템프 켜기

        if (questStempCount == 10)
        {
            User.Instance.AddUserTicketData();
            for (int i = 0; i < questStamp.Length; i++)
            {
                questStamp[i].gameObject.SetActive(false);
            }
            questStempCount = 0;
        }
    }

    // Start is called before the first frame update
    public void OnClikedCloseButton()
    {
        QuestStampCanvas.Instance.gameObject.SetActive(false);
    }

}
