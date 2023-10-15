using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Backpack : MonoBehaviour
{
    private float totalWeight = 0; 
    private const float maxWeight = 30f; 
    public GameObject itemSlotPrefab; 
    public Transform content; 

    private List<Item> items = new List<Item>();

    public float GetTotalWeight()
    {
        return totalWeight;
    }

    public bool AddItem(Item item)
    {
        if (totalWeight + item.weight <= maxWeight)
        {
            totalWeight += item.weight;
            items.Insert(0, item); // 将新物品添加到列表的开始位置
            GameObject newItemSlot = Instantiate(itemSlotPrefab, content);
            newItemSlot.transform.SetAsFirstSibling(); // 确保新的slot在顶部
            Tooltip tooltip = newItemSlot.GetComponent<Tooltip>();
            tooltip.SetItem(item); 
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
