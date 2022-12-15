using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnjingScripts : MonoBehaviour
{
    private float speedX;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        speedX = Random.Range(1.0f, 1.5f);
        animator = GetComponent<Animator>();
        animator.SetBool("isRun", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = Vector2.zero;
        v.x = 2;
        float speed = speedX * Time.deltaTime;
        transform.Translate(v * speed);
    }

}
