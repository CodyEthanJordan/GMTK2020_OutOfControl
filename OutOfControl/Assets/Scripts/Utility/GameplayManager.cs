using Assets.Scripts.Runner;
using Assets.Scripts.Shooter;
using System.Collections;
using UnityEngine;

public class GameplayManager : MonoSingleton<GameplayManager>
{
    protected GameplayManager() { }
    public RunnerGuy Runner;
    public CameraScroll CamRunner;
    public Animator FadeToBlack;
    public float RestartWaitTime = 1;
    public float Speed = 3;

    private Vector3 startingLine;
    private Vector3 camPos;

    private void Start() {
        camPos = CamRunner.transform.position;
        startingLine = Runner.transform.position;

        Runner.SetSpeed(Speed);
        CamRunner.SetSpeed(Speed);
    }

    public void RestartLevel() {
        Debug.Log("Restarting level");
        StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel() {
        FadeToBlack.SetTrigger("FadeOut");
        Runner.Stop();
        CamRunner.Stop();
        yield return new WaitForSeconds(RestartWaitTime);

        CamRunner.transform.position = camPos;
        Runner.transform.position = startingLine;
        FadeToBlack.SetTrigger("FadeIn");

        yield return new WaitForSeconds(0.1f);
        Runner.SetSpeed(Speed);
        CamRunner.SetSpeed(Speed);
    }
}
