using DUFE.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DUFE.Scene
{
    public class LevelLoad : MonoBehaviour
    {
        [Header("Event called on scene change")]
        public UnityEvent OnLevelLoading;
        [Header("Do the sound need to be fade out/fade in ?")]
        public bool fadeMusicOnLoad = false;
        [Header("Time used for the fade")]
        public float transitionTime = 1.2f;

        void OnEnable()
        {
            AudioManager m = FindObjectOfType<AudioManager>();
            m.FadeVol(1, 1);


        }


        public void LoadnextLevel(string scenename)
        {
            StartCoroutine(LevelLoading(scenename));
        }

        public void LoadnextLevel(int scenename)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(scenename).name);
            StartCoroutine(LevelLoading(SceneManager.GetSceneByBuildIndex(scenename).name));
        }

        IEnumerator LevelLoading(string scenename)
        {
            OnLevelLoading.Invoke();

            if (fadeMusicOnLoad == true)
            {
                AudioManager m = FindObjectOfType<AudioManager>();
                m.FadeVol(-80, transitionTime);
            }
            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(scenename);

        }
    }
}