using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public string itemName;
    public float estimatedValue;
    public float Value;

    public float initialweight;
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
        addToBackpackButton.onClick.AddListener(AddToBackpack);
        weight = Random.Range(initialweight * 0.8f, initialweight * 1.2f);
        weight = Mathf.Round(weight * 100f) / 100f;
        Value = Random.Range(estimatedValue * 0.8f, estimatedValue * 1.2f);
        Value = Mathf.Round(Value * 100f) / 100f;
        Debug.Log("Item Start"+owner);
   
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
        estimatedValueText.text = "Estimated Value: " + estimatedValue + "Yuan";
        weightText.text = "Weight: " + weight + "KG";
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
        if (ownerFixed)
        {
            return;
        }
        Debug.Log("Setting owner for " + itemName + " to " + newOwner);
        owner = newOwner;
        ownerFixed = true;
    }

     public void AddToBackpack()
    {
        if (playerBackpack.AddItem(this))
        {
            if (NPCDialogue.inRange)
            {
                NPCDialogue.currentNPC.StartD();
            }
            // �����Ʒ�ɹ���ӵ����������Խ�����������������������Ʒ����ð�ť
            itemInfoPanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public string GetInfo()
    {
        return itemName + "\n" + "Estimated Value: " + estimatedValue + "Yuan\n" + "Weight: " + weight + "KG\n" + "Owner: " + owner;
    }
}

