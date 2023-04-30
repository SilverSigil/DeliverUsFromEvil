using System;
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

        /// <summary>
        /// Create a fadeout on the sound by using the master channel on the mixer. 
        /// </summary>
        /// <param name="end">end value for volume Master.</param>
        /// <param name="time">time for the fadeout/fadein</param>
        internal void FadeVol(int end=0, float time = 1f)
        {
            StartCoroutine(fade(end, time));
        }

        IEnumerator fade(float end, float time)
        {
            float vol;
            _MasterMixer.GetFloat("Master", out vol);

            while (vol > end)
            {
                _MasterMixer.GetFloat("Master", out vol);
                _MasterMixer.SetFloat("Master", Mathf.Lerp(vol, end, time * Time.deltaTime));
                yield return 0f;
            }
        }

        public void SetUIVolume(Slider volume)
        {
            _MasterMixer.SetFloat("UI", volume.value);
        }

    }

}