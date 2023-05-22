using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundScript : MonoBehaviour
{
    public Toggle soundToggle;

    private void Start()
    {
    }

    public void ToggleSound()
    {
        if (soundToggle.isOn)
        {
            AudioManager.instance.UnMuteVolume();
        }
        else
        {
            AudioManager.instance.MuteVolume();
        }
    }
}