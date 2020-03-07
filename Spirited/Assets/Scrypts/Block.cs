using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed = 1;
    public int onLeft = 1;
    public int onMid = 1;
    public int onRight = 1;
    public string bKop;

    private void Start()
    {
        bKop = onLeft.ToString() + onMid.ToString() + onRight.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
