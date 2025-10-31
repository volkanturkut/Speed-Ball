using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RotateObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100f * Time.deltaTime);
    }
}
