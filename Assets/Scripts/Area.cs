using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public string owner; // �����ӵ����

    private BoxCollider2D boxCollider;

    void OnTriggerEnter2D(Collider2D col)
    {
        Item item = col.GetComponent<Item>();
        if(item && !item.ownerFixed)
        {
            item.SetOwner(owner);
        }
    }

}

