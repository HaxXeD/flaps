﻿using UnityEngine;
using System.Collections;

public class EaseUp : MonoBehaviour
{
    public IEnumerator StartEaseUp(float time, float timertime, Coroutine CoroutineType)
    { 
        yield return new WaitForSecondsRealtime(time);
        CoroutineType = StartCoroutine(ScaleTime(Time.timeScale,1f,timertime));   
    }

    public IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
        Time.timeScale = end;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
