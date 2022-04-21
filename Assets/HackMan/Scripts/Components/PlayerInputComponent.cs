using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using UnityEngine.SceneManagement;

public class PlayerInputComponent : MovementComponent
{
    public bool canCollect;//turning this thing on and off and it becomes a state Nightmare!
    public bool CanBeDamage;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    protected override void Update()
    {
        //calling 'base' calls the virtual method, first
        //we want to get player input first,BEFORE moving!
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = IntVector2.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = IntVector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = IntVector2.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = IntVector2.up;
        }
        

        //Debug.Log($"X:{currentInputDirection.x}|y:{currentInputDirection.y}");
        base.Update();
        //Debug.Log("overriding method...");
        //it will print "base methods.." then "overriding methods..."

    }

    private void OnTriggerEnter(Collider other)
    {
        //Write your logic for winning/losing
        //Destroy the pill
        //Check if all pills are gone + reload the level if so
        //Kill Hackman if it's the ghost

        if (other.GetComponent<Pill>() != null)
        {
            Destroy(other.gameObject);

            //Will be destroyed next frame, so we check length of 1
            if(FindObjectsOfType<Pill>().Length <= 1)
            {
                Debug.Log("You win!");
                SceneManager.LoadScene("Level");
            }
        }

        if (other.GetComponent<EnemyInputComponent>() != null)
        {
            Debug.Log("You Lose!");
            SceneManager.LoadScene("Level");

        }
    }

}
