using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Player;

public class InventoryManager : MonoBehaviour
{
    public List<DNAChip> chips = new List<DNAChip>();
    public Transform itemContent;
    public GameObject inventoryItem;
    [SerializeField] private PopUpWindow popUpWindow;
    [SerializeField] private GameObject popUpWindowSpawn;

    public void AddChip(DNAChip chipToAdd) {
        chips.Add(chipToAdd);
        InstantiateInInventory(chipToAdd);
        popUpWindow.ChangeText("Вы получили чип " + chipToAdd.name, popUpWindowSpawn.transform);
    }

    public void RemoveChip(DNAChip chipToRemove) {
        chips.Remove(chipToRemove);
        UpdateInventory();
    }

    public void UpdateInventory() {
        foreach (Transform item in itemContent) {
            Destroy(item.gameObject);
        }

        foreach (DNAChip chip in chips) {
            InstantiateInInventory(chip);
        }
    }

    private void InstantiateInInventory(DNAChip chip) {
        GameObject obj =  Instantiate(inventoryItem, itemContent);
        Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        itemName.text = chip.chipName;
        obj.GetComponent<InventoryItemController>().AddChip(chip);
    }
}
