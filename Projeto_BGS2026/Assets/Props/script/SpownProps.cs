using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SpownProps : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<GameObject> props = new List<GameObject>();
    public GameObject prop;
    void Start()
    {
        prop = props[Random.Range(0, props.Count)];
        Instantiate(prop,transform.position,prop.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
