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
    public bool ownerFixed = false; // �������ԣ�ָʾowner�Ƿ񱻹̶�

    public GameObject itemInfoPanel; // UI���
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI estimatedValueText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI ownerText;
    public Sprite icon; // �������ԣ���Ʒͼ��
    public Button closeButton; // �رհ�ť

    public Button addToBackpackButton; // ��ӵ�������ť
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

        // �������λ��Ϊ��Ʒ�Ϸ�
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)); // 1��λ�ߣ����Ե���
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
            // �����Ʒ�ɹ���ӵ����������Խ�����������������������Ʒ����ð�ť
            itemInfoPanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public string GetInfo()
    {
        return itemName + "\n" + "Estimated Value: " + estimatedValue + "\n" + "Weight: " + weight + "\n" + "Owner: " + owner;
    }
}

