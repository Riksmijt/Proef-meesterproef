using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Random = UnityEngine.Random;

public class speech_controll : MonoBehaviour
{
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip Aclip;
    private AudioSource soundSource;

    public float volumeController;

    public Text text;
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        keyActs.Add("Drum", activateDrum);
        keyActs.Add("Launchpad", activateLaunchpad);
        keyActs.Add("Play sample", playSample);
        keyActs.Add("Play again", playAgain);
        keyActs.Add("Sample volume up", sampleVolumeHigher);
        keyActs.Add("Sample volume down", sampleVolumeLower);
        keyActs.Add("Sample volume" + soundSource.ToString(), sampleVolume);
        keyActs.Add("Random pitch", playRandomPitch);
        keyActs.Add("Normal pitch", playNormalPitch);
        keyActs.Add("Stop sample", stopSample);
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
    void playSample()
    {
        Aclip = source.clip;
        source.PlayOneShot(Aclip);
    }
    void playAgain()
    {
        source.Stop();
        source.PlayOneShot(Aclip);
    }
    void sampleVolume()
    {
        source.volume = volumeController / 100;
    }
    void sampleVolumeHigher()
    {
        source.volume += 0.2f;
    }
    void sampleVolumeLower()
    {
        source.volume -= 0.2f;
    }
    void playRandomPitch()
    {
        source.pitch += Random.Range(-2, 2);
    }
    void playNormalPitch()
    {
        source.pitch = 1;
    }
    void stopSample()
    {
        source.Stop();
    }
   
}
