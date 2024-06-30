using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public List<DNAChip> goods = new List<DNAChip>();
    public Collider interactionZone;
    public TradeWindow tradeWindow;
    public Player player;

    void Start() {
        interactionZone = GetComponent<Collider>();
    }

    public void StartTrade() {
        tradeWindow.gameObject.transform.parent.parent.gameObject.SetActive(true);
    }

    public void BuyItem(DNAChip chip) {
        if (player.money >= chip.price) {
            player.money -= chip.price;
            player.GetChip(chip);
            goods.Remove(chip);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            player = other.gameObject.GetComponent<Player>();
            player.canBuy = true;
            player.seller = this;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) {
            player.canBuy = false;
        }
    }
}
