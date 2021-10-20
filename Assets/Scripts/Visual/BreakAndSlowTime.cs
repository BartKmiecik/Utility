using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAndSlowTime : MonoBehaviour
{
    [SerializeField] private GameObject brokenObject;

    public void BreakItself()
    {
        GameObject temp = Instantiate(brokenObject, transform);
        Destroy(temp, 2f);
        StartCoroutine(SlowsTime());
    }

    IEnumerator SlowsTime()
    {
        Time.timeScale = .1f;
        yield return new WaitForSeconds(.1f);
        Time.timeScale = .4f;
        yield return new WaitForSeconds(.1f);
        Time.timeScale = .8f;
        yield return new WaitForSeconds(.1f);
        Time.timeScale = 1f;
    }
    
}
