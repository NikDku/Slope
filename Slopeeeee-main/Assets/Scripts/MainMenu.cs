using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Transform cameraPos;
    private Vector3 camStartPos;
    [SerializeField] private Vector3 desiredCamPos;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject levelSelectScreen;
    private bool hasStarted = false;

    private void Start()
    {
        hasStarted = false;
        startScreen.SetActive(true);
        levelSelectScreen.SetActive(false);
        camStartPos = cameraPos.position;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if(!hasStarted)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                hasStarted = true;
                StartCoroutine(LerpCam(1));
            }
        }
    }

    public void PlayScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LerpCam(float duration)
    {
        startScreen.SetActive(false);
        float time = 0;

        while(time < duration)
        {
            cameraPos.position = Vector3.Lerp(camStartPos, desiredCamPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        cameraPos.position = desiredCamPos;
        levelSelectScreen.SetActive(true);
    }
}
