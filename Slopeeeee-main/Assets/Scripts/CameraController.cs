using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 offset;
    public Transform target;
    

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.HasPlayerFallenOff() && !GameManager.Instance.HasLevelEnded())
        {
            FollowTarget();
        } else
        {
            LookAtTarget();
        }
    }

    private void FollowTarget()
    {
        transform.rotation = Quaternion.identity;
        transform.position = target.position + offset;
    }

    private void LookAtTarget()
    {
        transform.LookAt(target.position);
    }

    public void LerpCamFOV(float FOV, float duration)
    {
        StartCoroutine(SmoothFOV(FOV, duration));
    }

    IEnumerator SmoothFOV(float FOV, float duration)
    {
        Camera cam = GetComponent<Camera>();
        float startFOV = cam.fieldOfView;
        float time = 0;

        while(time < duration)
        {
            cam.fieldOfView = Mathf.Lerp(startFOV, FOV, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        cam.fieldOfView = FOV;
    }
}
