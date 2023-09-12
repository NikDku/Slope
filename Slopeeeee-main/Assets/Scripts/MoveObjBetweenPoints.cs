using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjBetweenPoints : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPoint;
    [SerializeField]
    private Vector3 endPoint;
    private bool isMoving = false;
    [SerializeField]
    private float timeDuration = 2;
    [SerializeField]
    private float waitingTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            if (transform.localPosition == startPoint)
            {

                StartCoroutine(LerpPosition(endPoint, timeDuration));
            }
            else if (transform.localPosition == endPoint)
            {

                StartCoroutine(LerpPosition(startPoint, timeDuration));
            }
        }
    }

    IEnumerator LerpPosition(Vector3 destination, float duration)
    {
        isMoving = true;
        float time = 0;
        Vector3 startPosition = transform.localPosition;

        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(startPosition, destination, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = destination;

        yield return new WaitForSeconds(waitingTime);
        isMoving = false;
    }
}
