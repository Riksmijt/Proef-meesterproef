using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class speech_controll : MonoBehaviour
{
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    private AudioSource soundSource;

    public Text text;
    //public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        //Voice commands for changing color
        keyActs.Add("Drum", activateDrum);
        keyActs.Add("Launchpad", activateLaunchpad);
        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }
    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        text.text = args.text.ToString();
        keyActs[args.text].Invoke();
    }
    void activateDrum()
    {
        Debug.Log("Drum");

        play_instrument.drumIsActive = true;
        play_instrument.launchpadIsActive = false;
       
    }
    void activateLaunchpad()
    {
        Debug.Log("Hallo2");
        play_instrument.drumIsActive = false;
        play_instrument.launchpadIsActive = true;
    }
    /* void Talk()
     {
         soundSource.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
         soundSource.Play();
     }*/
    // Update is called once per frame
    private void Update()
    {
        
    }
}
