using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DUFE.UI.Effects
{

    public class TransitionManager : MonoBehaviour
    {
        public Animator anim;

        private void Start()
        {
            Image image = anim.gameObject.GetComponent<Image>();
            Debug.Log(image.color);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            Debug.Log(image.color);
        }

        public void fadeIn()
        {
            anim.SetTrigger("fadeIn");

        }
        public void fadeOut()
        {
            anim.SetTrigger("fadeOut");
        }
        public void completeFade()
        {
            StartCoroutine(startFade());

        }

        IEnumerator startFade()
        {
            fadeOut();
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length - 0.01f);
            fadeIn();
        }
    }

}