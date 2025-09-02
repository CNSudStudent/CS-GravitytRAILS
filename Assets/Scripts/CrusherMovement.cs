using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrusherMovement : MonoBehaviour
{
    public float xForce;
    public float yForce;
    private Rigidbody2D enemyRigidbody;
    public float xDirection;
    public int maximumXPosition;
    public int minimumXPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (transform.position.x <= minimumXPosition)
        {
            xDirection = 1;
            enemyRigidbody.AddForce(Vector2.right * xForce);
        }
        if (transform.position.x >= maximumXPosition)
        {
            xDirection = -1;
            enemyRigidbody.AddForce(Vector2.left * xForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grounds")
        {
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidbody.AddForce(jumpForce);
        }
    }
}
