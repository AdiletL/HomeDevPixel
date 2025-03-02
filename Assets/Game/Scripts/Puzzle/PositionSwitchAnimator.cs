using System.Collections;
using UnityEngine;

namespace Puzzle {

public class PositionSwitchAnimator : MonoBehaviour
{
    public Transform target;
    public Vector3 pos1;
    public Vector3 pos2;
    public float duration = 1.0f;
    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
    Coroutine SwitchPositionCoroutine;

    public void Switch()
    {
        if (SwitchPositionCoroutine != null)
        {
            StopCoroutine(SwitchPositionCoroutine);
        }

        SwitchPositionCoroutine = StartCoroutine(SwitchPosition());
    }

    public void Switch(bool toggle)
    {
        if (SwitchPositionCoroutine != null)
        {
            StopCoroutine(SwitchPositionCoroutine);
        }
        
        SwitchPositionCoroutine = StartCoroutine(SwitchPosition(toggle));
    }
    
    IEnumerator SwitchPosition()
    {
        float time = 0;
        Vector3 startPos = target.position;
        Vector3 endPos = target.position == pos1 ? pos2 : pos1;

        while (time < duration)
        {
            target.position = Vector3.Lerp(startPos, endPos, curve.Evaluate(time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        
        target.position = endPos;
    }

    IEnumerator SwitchPosition(bool toggle)
    {
        float time = 0;
        Vector3 startPos = target.position;
        Vector3 endPos = toggle ? pos2 : pos1;

        while (time < duration)
        {
            target.position = Vector3.Lerp(startPos, endPos, curve.Evaluate(time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        
        target.position = endPos;
    }
}

}