using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public string owner; // 区域的拥有者

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

