using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSolarRotate : MonoBehaviour
{
    public float speed = 0.005f;

    private int sign = 1;
    public float rot = 0;
    public bool exploded = false;

    private Animator animator;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!exploded)
        {
            if(Mathf.Abs(rot) > 180)
            {
                sign *= -1;
            }

            rot += sign * speed;

            transform.Rotate(sign * speed, 0, 0);
        }
    }
}
