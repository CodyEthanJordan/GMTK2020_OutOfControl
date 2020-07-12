using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public float Speed = 5;

    private void Update() {
        this.transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
    }

    public void Stop() {
        Speed = 0;
    }

    public void SetSpeed(float speed) {
        Speed = speed;
    }
}
