using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class CameraScroll : MonoBehaviour
    {
        public GameObject TargetToFollow;
        private CameraTrack cameraTrack; 

        private void Awake() {
            if (cameraTrack == null) cameraTrack = TargetToFollow.GetComponent<CameraTrack>();
        }

        private void Update() {
            this.transform.position = TargetToFollow.transform.position;
        }

        public void Stop() {
            cameraTrack.Stop();
        }

        public void SetSpeed(float speed) {
            cameraTrack.SetSpeed(speed);
        }
    }
}
