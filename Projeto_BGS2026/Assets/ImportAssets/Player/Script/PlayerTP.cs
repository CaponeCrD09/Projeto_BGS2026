using UnityEngine;

public class PlayerTP : MonoBehaviour
{

    public float speed;
    public GameObject tpob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tpob = GameObject.FindGameObjectWithTag("TP");
        if(tpob != null)
        {
            // Perform teleportation logic
            if(tpob.GetComponent<Disparo>().canTp)
            {
                //transform.position = tpob.transform.position;
                transform.position = Vector3.Lerp(transform.position, tpob.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
