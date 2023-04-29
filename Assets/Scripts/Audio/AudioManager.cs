using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace DUFE.Audio
{
    public class AudioManager : MonoBehaviour
    {

        public AudioMixer _MasterMixer;

        public void SetMasterVolume(Slider volume)
        {
            _MasterMixer.SetFloat("Master", volume.value);
        }

        public void SetMusicVolume(Slider volume)
        {
            _MasterMixer.SetFloat("Music", volume.value);
        }

        public void SetSFXVolume(Slider volume)
        {
            _MasterMixer.SetFloat("SFX", volume.value);
        }
        public void SetUIVolume(Slider volume)
        {
            _MasterMixer.SetFloat("tUI", volume.value);
        }

    }

}