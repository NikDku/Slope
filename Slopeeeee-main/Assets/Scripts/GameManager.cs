using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private bool isDead = false;
    private bool hasFallenOff = false;
    private bool hasLevelEnded = false;
    private bool isPaused = false;
    private GameObject player;
    private Rigidbody rb;
    private Vector3 startPos;
    private int score;
    [SerializeField] private GameObject dieFX;
    [SerializeField] private GameObject PauseMenu;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        startPos = player.transform.position;
        rb = player.GetComponent<Rigidbody>();
        score = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Start is called before the first frame update
    void Start()
    {
       if(Instance != null)
        {
            Debug.LogWarning("Instance already exisits! Destroying Object!");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddToScore()
    {
        score++;
    }

    public int GetScore()
    {
        return this.score;
    }
    
    public bool IsPlayerDead()
    {
        return isDead;
    }

    public bool HasPlayerFallenOff()
    {
        return hasFallenOff;
    }

    public bool HasLevelEnded()
    {
        return hasLevelEnded;
    }

    public void FallOff()
    {
        hasFallenOff = true;
        if (!IsInvoking()) Invoke(nameof(Respawn), 3);
    }

    public void Die()
    {
        isDead = true;
        Instantiate(dieFX, player.transform.position, Quaternion.identity);
        player.SetActive(false);
        if (!IsInvoking()) Invoke(nameof(Respawn), 3);

    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndLevel()
    {
        hasLevelEnded = true;
    }
}
