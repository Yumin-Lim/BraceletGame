using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FurniturePanelPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public FurnitureData furnitureData;

    public TMP_Text nameText;
    public TMP_Text price;
    public Image sprite;
    public string Key;




    void Start()
    {
        furnitureData.key = Key;
        nameText.text = furnitureData.furnitureName;
        price.text = furnitureData.price.ToString();
        sprite.sprite = furnitureData.prefab
            .GetComponentInChildren<SpriteRenderer>(true)
            .sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onClikedPurchaseButton()
    {
        User user = User.Instance;
        if (user.userData.coin < furnitureData.price)
        {
            Debug.Log("no money");
            return;
        }

        SoundManager.Instance.PlaySound(SoundType.Purchase);
        user.AddCoin(-furnitureData.price);
        user.AddFurniture(furnitureData);
    }
}
