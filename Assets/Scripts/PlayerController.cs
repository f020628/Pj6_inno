using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 玩家属性
    public float health = 100f;

    public float moveSpeed = 5f;
    // 移动和冲刺
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float currentSpeed;
    public Backpack backpack;   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;   
    }

    private void Update()
    {  
        currentSpeed = moveSpeed - (backpack.GetTotalWeight() * 0.1f);
        currentSpeed = Mathf.Max(0, currentSpeed);  // 保证速度不小于0
        HandleMovement();

    }
    private void FixedUpdate()
    {
        rb.velocity = moveInput * currentSpeed;
    }
    private void HandleMovement()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        // 添加惯性的逻辑...
    }

    
    public void Die()
    {
        SceneManager.LoadScene("End");
        // 处理玩家死亡逻辑...
    }


}
