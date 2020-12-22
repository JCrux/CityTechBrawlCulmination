using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour

{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        detectDirection();
    }

    void detectDirection()
    {
        Vector2 r = this.transform.position - target.position;
        if (r.x < 0)
        {

            transform.localScale = new Vector2(1, 1);
        }

        if (r.x > 0)
        {


            transform.localScale = new Vector2(-1, 1);//maybe 6.4 , for both ifs 
        }

    }
}
