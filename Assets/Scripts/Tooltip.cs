using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemIcon; // ��������ʾ��Ʒͼ���ͼ�����
    public GameObject tooltipPanel; 
    public TextMeshProUGUI tooltipText; 

    private void Start()
    {
        tooltipPanel.SetActive(false); // ȷ������ʼʱ�����ص�
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPanel.SetActive(false);
    }

    public void SetText(string text)
    {
        tooltipText.text = text;
    }

    public void SetItem(Item item)
    {
        Debug.Log("Item passed to SetItem: " + (item == null ? "NULL" : item.itemName));
        Debug.Log("ItemIcon reference: " + (itemIcon == null ? "NULL" : "SET"));

        itemIcon.sprite = item.icon; // ������������Ʒͼ��

        string text = "Item Name: " + item.itemName + "\n" +
                      "Estimated Value: " + item.estimatedValue + "\n" +
                      "Weight: " + item.weight + "\n" +
                      "Owner: " + item.owner;
        SetText(text);
    }
}
