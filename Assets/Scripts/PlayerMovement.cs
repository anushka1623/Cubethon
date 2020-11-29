using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Jumpspeed = 10f;
    public float Forwardforce = 2000f;
    public float sidewaysForce = 500f;
    public float distToGround = 0.6f;
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, Forwardforce * Time.deltaTime);
        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Vector3 jumpVelocity = new Vector3(0f, Jumpspeed, 0f);
            rb.velocity = rb.velocity + jumpVelocity;
        }
        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        bool isGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, distToGround);
        }
    }
}
