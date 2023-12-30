using UnityEngine;

public class Silver_Coin : MonoBehaviour
{
    public Rigidbody _rb;
    public float jumpHeight;
    bool objectGrounded = true;
    
   

    void FixedUpdate()
    {
        Fly();
    }

    void Fly()
    {
        if (objectGrounded == true)
        {
            _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Lane")
        {
            objectGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Lane")
        {
            objectGrounded = false;
        }
    }
}
