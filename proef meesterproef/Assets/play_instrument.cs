using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_instrument : MonoBehaviour
{
    public GameObject drum;
    public GameObject launchpad;

    public static bool drumIsActive;
    public static bool launchpadIsActive;
    // Start is called before the first frame update
    void Start()
    {
        drumIsActive = false;
        launchpadIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(drumIsActive == true && launchpadIsActive == false)
        {
            drum.SetActive(true);
            launchpad.SetActive(false);
        }
        if (launchpadIsActive == true && drumIsActive == false)
        {
            drum.SetActive(false);
            launchpad.SetActive(true);
        }
    }
}
