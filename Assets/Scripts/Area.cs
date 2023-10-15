using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public string owner; // �����ӵ����

    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        // ��ȡ�������ڵ�������ײ��
        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.size, 0);
        
        foreach(Collider2D col in colliders)
        {
            Item item = col.GetComponent<Item>();
            if(item)
            {
                item.SetOwner(owner);
            }
        }
    }
}

