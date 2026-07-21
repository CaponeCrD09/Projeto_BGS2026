using System.Collections;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velocidade = 30f;
    private Rigidbody rb;
    public bool canTp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * velocidade;
        Destroy(gameObject, 2f);
    }
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cenario")
        {
            canTp = true;
            StartCoroutine(DestroyAfterSeconds(0.2f));
        }
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }   
}