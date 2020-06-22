using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class playInstrument : MonoBehaviour
{
    [Header("Audio options")]
    [SerializeField] private AudioSource source;
    [SerializeField] private float pitchSensitivity;
    private float touchAmount = 0f;
    bool playFinished = false;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
           
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            
            if (Physics.Raycast(ray, out raycastHit))
            {
                playFinished = true;
                if (raycastHit.collider.tag == "drum")
                {
                    source.PlayOneShot(raycastHit.collider.gameObject.GetComponent<playAudio>().clip);
                }
            }
        }

        if (Input.touchCount == 1)
        {
            Touch touches = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.tag == "launchpad")
                {
                    switch (touches.phase)
                    {
                        case TouchPhase.Began:
                           
                            source.PlayOneShot(raycastHit.collider.gameObject.GetComponent<playAudio>().clip);
                            break;

                        case TouchPhase.Moved:
                            
                           // Debug.Log(touches.position.y);
                            //source.gameObject.GetComponent<AudioSource>().volume -= 0.01f;
                            if (touches.position.y > 250)
                            {
                                source.volume -= touches.position.y / 15000;
                            }
                            if (touches.position.y < 250)
                            {
                                source.volume += touches.position.y / 15000;
                            }
                            break;

                        case TouchPhase.Ended:
                          
                            source.Stop();
                            source.volume = 100;
                            source.pitch = 1;
                            break;
                    }
                }
            }

        }

        if (Input.touchCount > 1)
        {
            Touch touches = Input.GetTouch(1);

            switch (touches.phase)
            {
                case TouchPhase.Moved:
                    Debug.Log(touches.position.x);
                    //source.gameObject.GetComponent<AudioSource>().volume -= 0.01f;
                    if (touches.position.x < 150)
                    {
                        source.pitch -= touches.position.x / pitchSensitivity;
                    }
                    if (touches.position.x > 150)
                    {
                        source.pitch += touches.position.x / pitchSensitivity;
                    }
                    break;

                case TouchPhase.Ended:

                    source.volume = 100;
                    source.pitch = 1;
                    break;
            }
        }
    }
}




        
    

