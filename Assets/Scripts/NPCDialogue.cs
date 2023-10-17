using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public static NPCDialogue currentNPC;
    public enum type { Computer, Lamp, Tent};
    public type t;
    public TextMeshProUGUI dialogueText;
    public static TextMeshProUGUI playerText;

    public PlayerController playerController;

    private int playerCount = 0, npcCount = 0;
    private string[] playerDialogue;
    private string[] npcDialogue;
    // Start is called before the first frame update
    void Start()
    {
        playerText = GameObject.Find("Player").GetComponentInChildren<TextMeshProUGUI>();

        if(t == type.Lamp)
        {
            playerDialogue = PlayerDialogue.playerDialogue1;
            npcDialogue = PlayerDialogue.dialogue1;
        }
        else if(t == type.Computer)
        {
            playerDialogue = PlayerDialogue.playerDialogue2;
            npcDialogue = PlayerDialogue.dialogue2;
        }
        else
        {
            playerDialogue = PlayerDialogue.playerDialogue3;
            npcDialogue = PlayerDialogue.dialogue3;
        }
    }

    // Update is called once per frame
    public bool playerTurn = true;
    private bool dialogue = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogue)
        {
            if (playerCount == playerDialogue.Length && npcCount == npcDialogue.Length)
            {
                EndConversation();
            }
            else
            {
                if (playerTurn)
                {
                    playerText.text = playerDialogue[playerCount];
                    playerCount++;
                    playerTurn = false;
                }
                else
                {
                    dialogueText.text = npcDialogue[npcCount];
                    npcCount++;
                    playerTurn = true;
                }
            }
        }
    }

    void EndConversation()
    {
        playerController.enabled = true;
        dialogueText.text = ""; 
        playerText.text = "";
        playerTurn = true;
        dialogue = false;

        this.enabled = false;
    }

    public static bool inRange = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            currentNPC = this;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            currentNPC = null;
        }
    }

    public void StartD()
    {
        dialogue = true;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerController.enabled = false;

        if (playerTurn)
        {
            playerText.text = playerDialogue[playerCount];
            playerCount++;
            playerTurn = false;
        }
        else
        {
            dialogueText.text = npcDialogue[npcCount];
            npcCount++;
            playerTurn = true;
        }
    }


}
