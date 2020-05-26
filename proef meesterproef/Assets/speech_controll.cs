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
        keyActs.Add("Drum", Hallo1);
        keyActs.Add("Stampot", Hallo2);
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
    void Hallo1()
    {
        Debug.Log("Hallo1");
        
       
    }
    void Hallo2()
    {
        Debug.Log("Hallo2");
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
