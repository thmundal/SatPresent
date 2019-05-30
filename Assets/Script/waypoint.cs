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

    [System.Serializable]
    public struct AnimTrigger
    {
        public Transform animatedObject;
        public string trigger;
    }

    public AnimTrigger[] trigger_animations;

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
                //Debug.Log(newAlpha);
                canvasGroup.alpha = newAlpha;
            } else
            {
                canvasGroup.alpha = (fade_dir > 0 ? 1 : 0);

                if(fade_dir > 0)
                {
                    foreach(AnimTrigger anim in trigger_animations)
                    {
                        Animator animator = anim.animatedObject.GetComponent<Animator>();

                        if (animator != null)
                        {
                            animator.SetTrigger(anim.trigger);
                            Debug.Log("Trigger animation: " + anim.trigger);
                        }
                    }
                }
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
