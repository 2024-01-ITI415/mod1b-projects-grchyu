using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Insepector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftandRightEdge = 20f;
    public float chanceToChangeDirction=0.1f;
    public float secondsBetweenAppleDrop=2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple= Instantiate<GameObject>(applePrefab);
        apple.transform.position=transform.position;
        Invoke("DropApple", secondsBetweenAppleDrop);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftandRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftandRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirction)
        {
            speed *= -1;
        }
    }
}
