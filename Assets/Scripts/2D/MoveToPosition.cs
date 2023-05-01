using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DUFE.Character2D {
    public class MoveToPosition : MonoBehaviour
    {
        public Transform target; 
        private Vector3 positionToMoveTo;
        public float timeToTravel = 1f;
        private bool move = false;

        public bool Move { get => move; set => move = value; }

        void Start()
        {
            positionToMoveTo = new Vector3(target.position.x, transform.position.y, transform.position.z);
            if(move == true)
            { 
                if(target.position.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false; 
                } else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                StartCoroutine(LerpPosition(positionToMoveTo, timeToTravel));
            }
        }

        private void Update()
        {
            if (move == true)
            {
                if (target.position.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                StartCoroutine(LerpPosition(positionToMoveTo, timeToTravel));
            }

        }
        IEnumerator LerpPosition(Vector3 targetPosition, float duration)
        {
            float time = 0;
            Vector3 startPosition = transform.position;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
            move = false; 
        }

    }
}