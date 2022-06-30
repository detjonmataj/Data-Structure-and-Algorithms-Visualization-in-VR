using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp=GetComponent<Collider>().bounds.size;
        Debug.Log("x "+temp.x);
        Debug.Log("y: "+temp.y);
        Debug.Log("z "+temp.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

