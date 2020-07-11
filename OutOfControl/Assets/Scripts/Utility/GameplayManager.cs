using Assets.Scripts.Runner;
using Assets.Scripts.Shooter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class GameplayManager : MonoBehaviour
    {
        public RunnerGuy Runner;
        public CameraScroll CamRunner;
        public Animator FadeToBlack;
        public float RestartWaitTime = 1;
        public float Speed = 3;

        private Vector3 startingLine;
        private Vector3 camPos;

        private void Start()
        {
            camPos = CamRunner.transform.position;
            startingLine = Runner.transform.position;

            Runner.Speed = Speed;
            CamRunner.Speed = Speed;
        }

        public void RestartLevel()
        {
            Debug.Log("Restarting level");
            StartCoroutine(ResetLevel());
        }

        IEnumerator ResetLevel()
        {
            FadeToBlack.SetTrigger("FadeOut");
            Runner.Speed = 0;
            CamRunner.Speed = 0;
            yield return new WaitForSeconds(RestartWaitTime);

            CamRunner.transform.position = camPos;
            Runner.transform.position = startingLine;
            FadeToBlack.SetTrigger("FadeIn");

            yield return new WaitForSeconds(0.1f);
            Runner.Speed = Speed;
            CamRunner.Speed = Speed;

        }
    }
}
