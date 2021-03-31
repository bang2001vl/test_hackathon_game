using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc : MonoBehaviour
{
    // Start is called before the first frame update
    
    float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

   
    // Update is called once per frame
  
}
