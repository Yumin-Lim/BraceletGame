using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    
    public TMP_Text coinCounter;
    public TMP_Text levelCounter;

    public TMP_Text ticketCounter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        User user = User.Instance;
        coinCounter.text = user.userData.coin.ToString();
        levelCounter.text = user.userData.level.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        User user = User.Instance;
        coinCounter.text = user.userData.coin.ToString(); 

        levelCounter.text = user.userData.level.ToString();

        ticketCounter.text = user.userData.userTicketDatas.Count.ToString();
    }
}
