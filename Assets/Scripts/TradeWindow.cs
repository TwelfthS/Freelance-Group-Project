using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeWindow : MonoBehaviour
{
    public Seller seller;
    public GameObject tradeItem;

    void Awake() {
        UpdateTradeWindow();
    }

    public void Buy(DNAChip chip) {
        seller.BuyItem(chip);
        UpdateTradeWindow();
    }

    void UpdateTradeWindow() {
        foreach (Transform item in transform) {
            Destroy(item.gameObject);
        }

        foreach (DNAChip chip in seller.goods) {
            GameObject obj =  Instantiate(tradeItem, this.gameObject.transform);
            Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            itemName.text = chip.chipName;
            obj.GetComponent<InventoryItemController>().AddChip(chip);
        }
    }
}
