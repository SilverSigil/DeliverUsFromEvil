using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DUFE.Scene.Camera
{

    public class SwitchCamera : MonoBehaviour
    {
        List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
        // Start is called before the first frame update
        void Start()
        {
            cameras = FindObjectsOfType<CinemachineVirtualCamera>(true).ToList();
            var brain = CinemachineCore.Instance.GetActiveBrain(0);
            var activeCamera = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        }

        // Update is called once per frame
        void Update()
        {
            var brain = CinemachineCore.Instance.GetActiveBrain(0);
            var activeCamera = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();

        }

        public void Switch(CinemachineVirtualCamera camera)
        {
            foreach(CinemachineVirtualCamera c in cameras){
                c.Priority = 0;
            }
            camera.Priority = 10;
        }
    }

}