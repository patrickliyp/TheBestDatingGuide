using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emojipop : MonoBehaviour
{
    public static emojipop emojimanager;
    public GameObject[] Ironmanemojis;
    public GameObject[] Natemojis;
    public AudioClip soundeffect;
    Dictionary<string, int> mydict = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        emojimanager = this;
        mydict.Add("awkward", 0);
        mydict.Add("surprise", 1);
        mydict.Add("silence", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IronmanShowEmoji(string e)
    {
        foreach(GameObject emoji in Ironmanemojis)
        {
            emoji.SetActive(false);
        }
        int i = mydict[e];
        Ironmanemojis[i].SetActive(true);
        playsound();


    }
    public void NatShowEmoji(string e)
    {
        foreach (GameObject emoji in Natemojis)
        {
            emoji.SetActive(false);
        }
        int i = mydict[e];
        Natemojis[i].SetActive(true);
        playsound();
    }
    void playsound()
    {
        GetComponent<AudioSource>().Play();
    }
}
