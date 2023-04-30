using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DUFE.UI
{
    public class UIManager : MonoBehaviour
    {
        private DataHolder dh;
        private float rating;
        [Header("Rating Object View")]
        public GameObject ratingObj;
        [Header("Prefabs rating")]
        public GameObject ratingStarNotFilledPrefab;
        public GameObject ratingStarFilledPrefab;

        private void Start()
        {
            dh = FindObjectOfType<DataHolder>();
            rating = dh.characterRating;
            generateRating();
        }

        private void Update()
        {
            
        }
        public void generateRating()
        {
            for (int i = 0; i < 5; i++)
            {
                if(i < rating)
                {
                    Instantiate(ratingStarFilledPrefab, ratingObj.transform);

                } else
                {
                    Instantiate(ratingStarNotFilledPrefab, ratingObj.transform);

                }
            }
        }

    }


}