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
        public AudioSource sourceUI;
        public AudioSource sourceSFX;
        public AudioSource sourceMusic; 
        public AudioMixer _MasterMixer;

        public void SetMasterVolume(Slider volume)
        {
            _MasterMixer.SetFloat("Master", Mathf.Log(volume.value) * 20);
        }

        public void SetMusicVolume(Slider volume)
        {

            _MasterMixer.SetFloat("Music", Mathf.Log(volume.value) * 20);
        }

        public void SetSFXVolume(Slider volume)
        {
            _MasterMixer.SetFloat("SFX", Mathf.Log(volume.value) * 20);
        }

        /// <summary>
        /// Create a fadeout on the sound by using the master channel on the mixer. 
        /// </summary>
        /// <param name="end">end value for volume Master.</param>
        /// <param name="time">time for the fadeout/fadein</param>
        internal void FadeVol(int end=-80, float time = 1f)
        {
            StartCoroutine(fade(end, time));
        }

        IEnumerator fade(float end, float time)
        {
            float currentTime = 0;
            float currentVol;
            _MasterMixer.GetFloat("Master", out currentVol);
            currentVol = Mathf.Pow(10, currentVol / 20);
            float targetValue = Mathf.Clamp(Mathf.Pow(10, end / 20), 0.0001f, 1);
            while (currentTime < time)
            {
                currentTime += Time.deltaTime;
                float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / time);
                _MasterMixer.SetFloat("Master", Mathf.Log10(newVol) * 20);
                yield return null;
            }
            yield break;
        }

        public void SetUIVolume(Slider volume)
        {
            _MasterMixer.SetFloat("UI", Mathf.Log(volume.value) * 20);
        }

    }

}