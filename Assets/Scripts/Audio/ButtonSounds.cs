using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DUFE.Audio
{

    namespace UI
    {
        public class ButtonSounds : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
        {
            private AudioManager am;
            private AudioSource sfxSource;
            public AudioClip hoverFX;
            public AudioClip clickFX;

            public void HoverSound()
            {
                sfxSource.PlayOneShot(hoverFX);
            }

            public void ClickSound()
            {
                sfxSource.PlayOneShot(clickFX);
            }

            void Start()
            {
                sfxSource = FindObjectOfType<AudioManager>().sourceSFX;
            }

            public void OnPointerClick(PointerEventData eventData)
            {
                if (clickFX != null)
                {
                    ClickSound();
                }
            }

            public void OnPointerEnter(PointerEventData eventData)
            {
                if (hoverFX != null)
                {
                    HoverSound();
                }
            }
        }
    }
}