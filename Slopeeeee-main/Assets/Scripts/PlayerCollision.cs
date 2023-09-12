using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GameManager.Instance.Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            GameManager.Instance.AddToScore();
            Destroy(other.gameObject);

            if (scoreTxt != null) scoreTxt.SetText(GameManager.Instance.GetScore().ToString());
        }
    }


}
