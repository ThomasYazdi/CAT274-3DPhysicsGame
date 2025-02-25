using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 8.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            GameManager.Instance.Score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.Score--;
            Destroy(collision.gameObject);
        }
    }
}
