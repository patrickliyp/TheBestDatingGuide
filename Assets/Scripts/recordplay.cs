using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class recordplay : MonoBehaviour
{
    //A boolean that flags whether there's a connected microphone  
    private bool micConnected = false;

    //The maximum and minimum available recording frequencies  
    private int minFreq;
    private int maxFreq;

    //A handle to the attached AudioSource  
    private AudioSource goAudioSource;

    float timeLeft = 5.0f;
    float recordTime;
    public GameObject timer;
    Text timertext;
    int count = 0;

    void Awake()
    {
        timertext = timer.GetComponent<Text>();
    }

    //Use this for initialization  
    void Start()
    {
        //Check if there is at least one microphone connected  
        if (Microphone.devices.Length <= 0)
        {
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");
        }
        else //At least one microphone is present  
        {
            //Set 'micConnected' to true  
            micConnected = true;

            //Get the default microphone recording capabilities  
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...  
            if (minFreq == 0 && maxFreq == 0)
            {
                //...meaning 44100 Hz can be used as the recording sampling rate  
                maxFreq = 44100;
            }

            //Get the attached AudioSource component  
            goAudioSource = this.GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            timeLeft = 0.0f;
            count = 1;
            timer.SetActive(false);
        }
        if (count == 1)
            recordTime += Time.deltaTime;

        timertext.text = "time Left:" + timeLeft;

    }

    void OnGUI()
    {
        //If there is a microphone  
        if (micConnected)
        {
            //If the audio from any microphone isn't being captured  
            if (!Microphone.IsRecording(null) && (timeLeft == 0.0f))
            {
                //Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource  
                goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);

            }
            else //Recording is in progress  
            {
                if (timeLeft == 0.0f)
                {
                    if (recordTime > 10.0f)
                    {
                        //Case the 'Stop and Play' button gets pressed  
                        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Stop Recording!"))
                        {
                            SavWav.Save("myfile", goAudioSource.clip);
                            Microphone.End(null); //Stop the audio recording  
                            goAudioSource.Play(); //Playback the recorded audio  
                        }
                    }

                    GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 50), "Recording in progress...");
                }
            }
        }
        else // No microphone  
        {
            //Print a red "Microphone not connected!" message at the center of the screen  
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Microphone not connected!");
        }

    }
}
