using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatController : MonoBehaviour
{
    AutoSolarRotate rotator;
    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInChildren<AutoSolarRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StopAutoRotation()
    {
        if(rotator != null)
        {
            rotator.exploded = true;
            //rotator.transform.rotation *= Quaternion.Euler(0, 1, 1);
            rotator.transform.Rotate(-rotator.rot, 0, 0);
            rotator.rot = 0;
            Debug.Log("Stop the rotation pls");
        }
    }

    public void StartAutoRotation()
    {
        rotator.exploded = false;
    }
}
