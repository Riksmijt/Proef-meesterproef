using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System;

public class voice_commands : MonoBehaviour
{
    public KeywordRecognizer keywordRecognizer;
    public GameObject dinkie;

    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        actions.Add("hello", hello);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += incomingVoice;
        keywordRecognizer.Start();
        
    }
    private void incomingVoice(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void hello()
    {
        Debug.Log("hello");
        dinkie.GetComponent<MeshRenderer>().material.color = new Color(20, 20, 20);
    }
}
