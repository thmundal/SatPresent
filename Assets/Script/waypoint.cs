using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waypoint : MonoBehaviour
{
    public int number;
    public GameObject UIContainer;

    public CanvasGroup canvasGroup;
    private int fade_dir = 0;
    private float fade_speed = 1;

    private void Start()
    {
        if(UIContainer != null)
        {
            canvasGroup = UIContainer.GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
        }
    }

    private void Update()
    {
        if(fade_dir != 0 && UIContainer != null)
        {
            
            float alpha = canvasGroup.alpha;
            float newAlpha = alpha + fade_speed * fade_dir * Time.deltaTime;


            if (newAlpha > 0 && newAlpha < 1)
            {
                Debug.Log(newAlpha);
                canvasGroup.alpha = newAlpha;
            } else
            {
                stopFade();
            }
        }
    }

    public void fadeOut(float s)
    {
        fade_dir = -1;
        fade_speed = s;
    }

    public void fadeIn(float s)
    {
        fade_dir = 1;
        fade_speed = s;
    }

    public void stopFade()
    {
        fade_dir = 0;
    }
}
