using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public DNAChip chip;
    public Player player;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void AddChip(DNAChip _chip) {
        chip = _chip;
    }

    public void EquipChip() {
        player.EquipChip(chip);
    }

    public void HandleClick() {
        TradeWindow tw = this.gameObject.transform.parent.gameObject.GetComponent<TradeWindow>();
        if (tw != null) {
            tw.Buy(chip);
        } else {
            EquipChip();
        }
    }
}
