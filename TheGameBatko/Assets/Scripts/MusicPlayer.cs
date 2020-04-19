using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    bool musicOn = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.HasKey("MusicEnable"))
        {
            if (PlayerPrefs.GetString("MusicEnable") == "True")
            {
                musicOn = true;
            }

            else if (PlayerPrefs.GetString("MusicEnagle") == "False")
            {
                musicOn = false;
            }
        }

        TryPlayMusic();
    }
    void TryPlayMusic()
    {
        if (musicOn)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    public void ToggleMusic()
    {
        if (musicOn)
        {
            musicOn = false;
            PlayerPrefs.SetString("MusicEnabled", "False");
        }
        else
        {
            musicOn = true;
            PlayerPrefs.SetString("MusicEnabled", "False");
        }
        TryPlayMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
        