using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 400f;
    private Rigidbody2D playerRb;
    public bool isDead;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            playerRb.gravityScale = 1.6f;
            Flight();
        }
    }

    public void Flight()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * upForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GameManager.Instance.GameOver();
    }
}
