using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvlOnTrigger : MonoBehaviour
{
    [SerializeField] private EndingCollider type;

    private enum EndingCollider
    {
        SpeedUp,
        End
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if(type == EndingCollider.SpeedUp)
        {
            other.gameObject.GetComponent<PlayerController>().SetMovable(false);
            FindObjectOfType<CameraController>().LerpCamFOV(100, 2);
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.maxAngularVelocity = Mathf.Infinity;
            rb.AddForceAtPosition(Vector3.forward * 1000 * 70 * rb.mass * Time.deltaTime, transform.position);
        } else if(type == EndingCollider.End)
        {
            GameManager.Instance.EndLevel();
            if (!IsInvoking()) Invoke(nameof(LoadNextLevel), 5);
        }
    }

    private void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
