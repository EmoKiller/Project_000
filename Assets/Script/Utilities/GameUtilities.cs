using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;
using UnityEngine.Events;

public static class GameUtilities
{
    public static void DelayCall(this MonoBehaviour mono, float time, Action callBack)
    {
        mono.StartCoroutine(IEDelayCall(time, callBack));
    }
    public static IEnumerator IEDelayCall(float time, Action callBack)
    {
        yield return new WaitForSeconds(time);
        callBack?.Invoke();
    }
    public static void LoopDelayCall(this MonoBehaviour mono, float endtime, Action callBack)
    {
        mono.StartCoroutine(IELoopDelayCall(endtime, callBack));
    }
    public static IEnumerator IELoopDelayCall(float endtime, Action callBack)
    {
        float StartTime = 0;
        while (StartTime <= endtime)
        {
            callBack?.Invoke();
            StartTime += Time.deltaTime;
            yield return null;
        }
    }
    public static void LoopCondition(this MonoBehaviour mono, bool condition, float waitForSeconds, Action callBack)
    {
        mono.StartCoroutine(IELoopCondition(condition, waitForSeconds, callBack));
    }
    public static IEnumerator IELoopCondition(bool condition, float waitForSeconds, Action callBack)
    {
        while (condition == true)
        {
            callBack?.Invoke();
            yield return new WaitForSeconds(waitForSeconds);
        }
    }
    public static void WaitDelayCall(this MonoBehaviour mono, int repeat, float waittime, Action callBack)
    {
        mono.StartCoroutine(IEWaitDelayCall(repeat, waittime, callBack));
    }
    public static IEnumerator IEWaitDelayCall(int repeat, float waittime, Action callBack)
    {
        int Current = 0;
        while (Current < repeat)
        {
            callBack?.Invoke();
            Current++;
            yield return new WaitForSeconds(waittime);
        }
    }
    //public static void WaitUntil(this MonoBehaviour mono, bool condition, UnityAction action)
    //{
    //    mono.StartCoroutine(IEWaitUntil(condition, action));
    //}
    //public static IEnumerator IEWaitUntil(bool condition, UnityAction action)
    //{
    //    yield return new WaitUntil(() => condition);
    //    action?.Invoke();
    //}
    public static void ReSetEulerAngle(this Transform trans)
    {
        trans.eulerAngles = new Vector3(15, 0, 0);
    }
    public static T TryGetMonoComponent<T>(this MonoBehaviour mono, ref T tryValue)
    {
        if (tryValue == null)
            tryValue = mono.GetComponent<T>();
        return tryValue;
    }
    public static T TryGetMonoComponentInChildren<T>(this MonoBehaviour mono, ref T tryValue)
    {
        if (tryValue == null)
            tryValue = mono.GetComponentInChildren<T>();
        return tryValue;
    }
    public static List<T> TryGetMonoComponentsInChildren<T>(this MonoBehaviour mono, ref List<T> tryValue)
    {
        if (tryValue == null)
            tryValue = mono.GetComponentsInChildren<T>().ToList();
        return tryValue;
    }
    public static void AniDropItem(this Transform trans)
    {
        //trans.transform.DOJump(new Vector3(UnityEngine.Random.Range(-2f, 2f), 0.5f, UnityEngine.Random.Range(-0.1f, -2f)) + trans.transform.position, UnityEngine.Random.Range(0.5f, 4f), 1, 0.3f);
    }
    public static void ScreenRayCastOnWorld(Action<Vector3> action)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            action?.Invoke(new Vector3(raycastHit.point.x, 0, raycastHit.point.z));
        }
    }
    public static Vector3 ScreenRayCastOnWorld(out Ray rays)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) 
        {
        }
        rays = ray;
        return raycastHit.point;
    }
}
