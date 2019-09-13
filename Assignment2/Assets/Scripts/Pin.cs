using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;
    private bool isHit = false;

    public float speed = 20f;
    public Rigidbody2D rb;

   

    private void Update()
    {
        if (!isPinned)
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pin")
        {
            isHit = true;
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (collision.tag == "Rotator")
        {
            if (isHit != true)
                Score.PinCount++;
            transform.SetParent(collision.transform);
            isPinned = true;
        }

        
       
    }
}
