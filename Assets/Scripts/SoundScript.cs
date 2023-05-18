using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundScript : MonoBehaviour
{

    [SerializeField] Button SoundOn;
    [SerializeField] Button SoundOff;

    // Start is called before the first frame update
    void Start()
    {
        SoundOn.onClick.AddListener(AudioManager.instance.UnMuteVolume);
        SoundOff.onClick.AddListener(AudioManager.instance.MuteVolume);
    }


}
