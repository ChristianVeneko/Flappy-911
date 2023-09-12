using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float spriteWidth;
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWidth)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {

        Vector2 vector = new Vector2(spriteWidth * 2f, 0);
        transform.position = (Vector2)transform.position + vector;

    }
}
