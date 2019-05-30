using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class followpath : MonoBehaviour
{
    public List<waypoint> waypoints;
    public int position = 0;
    public float speed = 1;
    public int dir = 0;

    private waypoint current;

    [Range(0, 100)]
    public float fadeSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        waypoint[] points = FindObjectsOfType<waypoint>();

        foreach(waypoint p in points)
        {
            waypoints.Add(p);
            
        }
        waypoints = waypoints.OrderBy(p => p.number).ToList();

        transform.position = waypoints[0].transform.position;
        transform.rotation = waypoints[0].transform.rotation;
        waypoints[0].fadeIn(fadeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.PageDown))
        {
            Advance();
        } else if(Input.GetMouseButtonDown(1) || Input.GetKeyUp(KeyCode.PageUp))
        {
            Return();
        }

        if(position < waypoints.Count)
        {
            waypoint wp = waypoints[position];
            
            float distance = Vector3.Distance(transform.position, wp.transform.position);

            //waypoint previous = getPrevious();
            //previous.fadeOut(fadeSpeed / distance);

            
            if (distance > 0.5)
            {
                if(current != null)
                {
                    current.fadeOut(fadeSpeed);
                }
                // Add fade transition here
                wp.fadeIn(fadeSpeed);

                transform.rotation = Quaternion.Lerp(transform.rotation, wp.transform.rotation, speed / distance * Time.deltaTime);
                Vector3 direction = (wp.transform.position - transform.position).normalized;
                Vector3 velocity = direction * speed * Time.deltaTime;
                transform.position += velocity;
            } else
            {
                transform.position = wp.transform.position;
            }

            current = wp;
        }
    }

    public waypoint getPrevious()
    {
        if(position > 0)
        {
            return waypoints[position - 1];
        } else
        {
            return waypoints[waypoints.Count - 1];
        }
    }

    public waypoint getNext()
    {
        if(position + 1 < waypoints.Count)
        {
            return waypoints[position + 1];
        } else
        {
            return waypoints[0];
        }
    }

    public void Advance()
    {
        dir = 1;
        if (position < waypoints.Count)
        {
            position++;
        } else
        {
            position = 0;
        }
    }

    public void Return()
    {
        dir = -1;
        if(position > 0)
        {
            position--;
        } else
        {
            position = waypoints.Count - 1;
        }
    }
}
