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

        private void Start() {
            if(TargetToFollow == null)
            {
                TargetToFollow = GameObject.FindGameObjectWithTag("Runner");
            }
            if (cameraTrack == null) cameraTrack = TargetToFollow.GetComponent<CameraTrack>();
        }

        private void Update() {
            var pos = new Vector3(TargetToFollow.transform.position.x, TargetToFollow.transform.position.y, this.transform.position.z);
            this.transform.position = pos;
        }

        public void Stop() {
            cameraTrack.Stop();
        }

        public void SetSpeed(float speed) {
            cameraTrack.SetSpeed(speed);
        }
    }
}
