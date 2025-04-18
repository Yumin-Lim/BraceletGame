using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatProductPanel : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Image thumImage;
    public string CatKey;
    public TMP_Text concept;


    public CatData catData;



    // Start is called before the first frame update
    void Start()
    {
        CatManager catmgr = FindObjectOfType<CatManager>();
        catData = catmgr.GetCatData(CatKey);

        nameText.text = catData.name;
        priceText.text = catData.price.ToString();
        thumImage.sprite = catData.thum;
        concept.text = catData.concept.ToString();





    }
    public void OnClickedPurchaseButton()
    {
        User user = User.Instance;
        if (user.userData.coin < catData.price)
        {
            Debug.Log("no money");
            return;
        }
        if (user.userData.coin > catData.price)
        {
            user.userData.coin -= catData.price;
        }
        user.AddCoin(-catData.price);
        user.AddCat(CatKey, 1);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
