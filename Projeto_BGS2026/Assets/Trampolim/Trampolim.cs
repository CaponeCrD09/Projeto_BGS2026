using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rig = collision.gameObject.GetComponent<Rigidbody>();

        if(rig != null)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         }
    }
}
