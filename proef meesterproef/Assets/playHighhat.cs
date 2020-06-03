using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class playHighhat : MonoBehaviour
{
    public AudioClip highhat;
    public AudioSource source;
    bool playFinished = false;

    void Update()
    {
       
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // Create a particle if hit
                if (Physics.Raycast(ray))
                    source.PlayOneShot(highhat);
                    playFinished = true;


               Debug.Log(Input.touchCount);
            }

            /*   if (Input.GetTouch(i).phase == TouchPhase.Ended)
               {
                   playFinished = false;

               }
           }
           if (playFinished == true)
           {
               i = 0;
           }
           else if (playFinished == false)
           {
               i = Input.touchCount;
           }*/
        }
    }

