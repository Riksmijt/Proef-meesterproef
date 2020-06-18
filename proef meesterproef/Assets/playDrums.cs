using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class playDrums : MonoBehaviour
{

    public AudioSource source;
    private float touchAmount = 0f;
    bool playFinished = false;



    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            // Create a particle if hit
            if (Physics.Raycast(ray, out raycastHit))
            {

                playFinished = true;
                if (raycastHit.collider.tag == "drum")
                {
                    source.PlayOneShot(raycastHit.collider.gameObject.GetComponent<playAudio>().clip);

                }
                /* if (raycastHit.collider.tag == "launchpad")
                 {

                         source.PlayOneShot(raycastHit.collider.gameObject.GetComponent<playAudio>().clip);
                         source.gameObject.GetComponent<AudioSource>().pitch += touch.position.y;

                 }*/

            }
        }
        if (Input.touchCount > 0)
        {

            Touch touches = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.tag == "launchpad")
                {


                    // Handle finger movements based on TouchPhase
                    switch (touches.phase)
                    {
                        //When a touch has first been detected, change the message and record the starting position
                        case TouchPhase.Began:
                            // Record initial touch position.
                            // source.gameObject.GetComponent<AudioSource>().pitch = touches.position.y;
                            source.PlayOneShot(raycastHit.collider.gameObject.GetComponent<playAudio>().clip);
                            break;

                        //Determine if the touch is a moving touch
                        case TouchPhase.Moved:
                            // Determine direction by comparing the current touch position with the initial one
                            Debug.Log(touches.position.y);
                            //source.gameObject.GetComponent<AudioSource>().volume -= 0.01f;
                            if (touches.position.y > 250)
                            {
                                source.gameObject.GetComponent<AudioSource>().volume -= touches.position.y / 15000;
                            }
                            if (touches.position.y < 250)
                            {
                                source.gameObject.GetComponent<AudioSource>().volume += touches.position.y / 15000;
                            }
                                break;

                        case TouchPhase.Ended:
                            // Report that the touch has ended when it ends
                            source.Stop();
                            source.gameObject.GetComponent<AudioSource>().volume = 100;
                            break;
                    }
                }
            }
        }
    }
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
        
    

