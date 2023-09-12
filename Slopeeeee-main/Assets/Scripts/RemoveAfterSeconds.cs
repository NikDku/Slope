using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterSeconds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyObj), 5);
    }

    private void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
