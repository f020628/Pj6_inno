using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    public List<GameObject> contents;
    private bool empty = false;
    private int count = 0;
    public GameObject panel;
    void Start()
    {
        count = contents.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(contents.Count == 0)
        {
            panel.SetActive(false);
            this.enabled = false;
        }
    }
    public void Search()
    {   if (empty)
        {
            return;
        }
        GameObject content = contents[0];
        contents.RemoveAt(0);
        count--;
        if (count == 0)
        {
            empty = true;
        }
        Vector3 position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        Instantiate(content, position, Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        panel.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
    }
}
