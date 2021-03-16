using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{

    Animator animator;

    int animationValue = 0;
    float rotationTime = 0;
    Vector3 direction = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void setRun()
    {
        animationValue = 1;
    }

    public void setHit()
    {
        animationValue = 2;
    }

    public void setIdle()
    {
        animationValue = 0;
    }

    public void setDirection(Vector3 direction)
    {
        this.direction = direction;
        transform.rotation = Quaternion.LookRotation(Quaternion.AngleAxis(-90, Vector3.up) * this.direction, Vector3.up);
        rotationTime = 0;
    }

    private void rotateIfNecessary()
    {
            

    }

    // Update is called once per frame
    void Update()
    {
        rotateIfNecessary();

        if (animationValue == 0)
        {
            animator.SetBool("run", false);
            animator.SetBool("interact", false);
        }
        if (animationValue == 1)
        {
            animator.SetBool("run", true);
            animator.SetBool("interact", false);
        }
        if (animationValue == 2)
        {
            animator.SetBool("run", false);
            animator.SetBool("interact", true);
        }

        
    }
}
