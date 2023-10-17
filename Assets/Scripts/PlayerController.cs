using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // �������
    public float health = 100f;

    public float moveSpeed = 5f;
    // �ƶ��ͳ��
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
        currentSpeed = Mathf.Max(0, currentSpeed);  // ��֤�ٶȲ�С��0
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
        // ��ӹ��Ե��߼�...
    }

    
    public void Die()
    {
        SceneManager.LoadScene("End");
        // ������������߼�...
    }


}
