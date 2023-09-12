using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAroundAxis : MonoBehaviour
{
    public enum Axis
    {
        X,
        Y,
        Z
    }


    [SerializeField] private Axis axis;
    [SerializeField] private float speedMultiplier = 1;
    private float xMultiplier = 0f;
    private float yMultiplier = 0f;
    private float zMultiplier = 0f;

    private Vector3 rotation;

    private void Awake()
    {
        switch(axis)
        {
            case Axis.X:
                xMultiplier = 1f;
                break;
            case Axis.Y:
                yMultiplier = 1f;
                break;
            case Axis.Z:
                zMultiplier = 1f;
                break;
            default:
                break;
        }

        rotation = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += new Vector3(xMultiplier, yMultiplier, zMultiplier) * speedMultiplier * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
