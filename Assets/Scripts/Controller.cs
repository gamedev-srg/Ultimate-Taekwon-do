using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float jump = 4f;
    [SerializeField] bool isGrounded;
    Rigidbody rb;
    Animator animator;
    Kick kicker;
    // Start is called before the first frame update
    void Start()
    {
        kicker = GetComponentInChildren<Kick>();//kick object
        animator = GetComponentInChildren<Animator>(); //animations
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerStay(Collider other) //WIP isGrounded not using character controller.
    {
        if (other.transform.tag == "Ground")
        {
            isGrounded = true;
          //  Debug.Log("Grounded");
        }
        else
        {
            isGrounded = false;
           // Debug.Log("Not Grounded!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //move left and right(sliding)
        rb.AddForce(Vector3.right * speed * x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) // only jump if grounded.
            {
                rb.AddForce(Vector3.up * jump,ForceMode.Impulse);
                isGrounded = false;
            }
        }
        if (Input.GetButtonDown("Fire1")) //kick
        {
            kicker.attackKick();
        }
    }































}
