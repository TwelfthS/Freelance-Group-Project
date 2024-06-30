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
}
