using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public string itemName;
    public float estimatedValue;
    public float weight;
    public string owner;
    public bool ownerFixed = false; // 新增属性，指示owner是否被固定

    public GameObject itemInfoPanel; // UI面板
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI estimatedValueText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI ownerText;
    public Sprite icon; // 新增属性，物品图标
    public Button closeButton; // 关闭按钮

    public Button addToBackpackButton; // 添加到背包按钮
    private Backpack playerBackpack;
    private void Awake()
{
    playerBackpack = GameObject.FindGameObjectWithTag("Backpack").GetComponent<Backpack>();
}
    private void Start()
    {
        closeButton.onClick.AddListener(ClosePanel);
        itemInfoPanel.SetActive(false);
        Debug.Log("Item Start"+owner);
        addToBackpackButton.onClick.AddListener(AddToBackpack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowItemInfo();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ClosePanel();
        }
    }

    private void ShowItemInfo()
    {
        itemNameText.text = "Item Name: " + itemName;
        estimatedValueText.text = "Estimated Value: " + estimatedValue;
        weightText.text = "Weight: " + weight;
        ownerText.text = "Owner: " + owner;

        // 设置面板位置为物品上方
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)); // 1单位高，可以调整
        itemInfoPanel.transform.position = screenPosition;

        itemInfoPanel.SetActive(true);
        addToBackpackButton.interactable = true;
    }

    public void ClosePanel()
    {
        itemInfoPanel.SetActive(false);
    }
    public void SetOwner(string newOwner)
    {
        owner = newOwner;
    }

     public void AddToBackpack()
    {
        if (playerBackpack.AddItem(this))
        {
            // 如果物品成功添加到背包，可以进行其他操作，例如隐藏物品或禁用按钮
            itemInfoPanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public string GetInfo()
    {
        return itemName + "\n" + "Estimated Value: " + estimatedValue + "\n" + "Weight: " + weight + "\n" + "Owner: " + owner;
    }
}

