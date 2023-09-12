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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            playerRb.AddForce(Vector2.up * upForce);
            playerRb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GameManager.Instance.GameOver();
    }
}
