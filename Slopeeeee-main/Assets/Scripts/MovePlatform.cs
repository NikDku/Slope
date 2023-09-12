using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private Vector3 desiredPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(LerpPos(5));
    }

    IEnumerator LerpPos(float duration)
    {
        float time = 0;
        transform.position = startPos;

        while(time < duration)
        {
            transform.position = Vector3.Lerp(startPos, desiredPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = desiredPos;

        StartCoroutine(LerpPos(5));
    }
}
