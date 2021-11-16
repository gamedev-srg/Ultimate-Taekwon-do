using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    //script for the kick 'collider'(game object).
    
    // used to distinguish between regular collisions, and attacking collisions.
    public bool attacking = false;

    //how long the attack takes.
    private float attack_duration = 0.5f;
    [SerializeField] private bool canAttack = true; //disabling too many kicks.
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy") //if we collided with an enemy AND we are in an attack animation (attacking flag)
        { 
          if (attacking)
          {
                var healthSystem = other.GetComponent<HealthSystem>(); //damage the enemy
                healthSystem.takeDamage(1);
            Debug.Log("Kicked");
          }
        }
        //attacking = false;
    }
   
    public void attackKick() //called from the controller this triggers the animation and sets the attacking flag to true.
    {
        if (canAttack) // if we can attack
        {
            animator.SetTrigger("Kick"); //start animation
            attacking = true; //enable damaging 
            canAttack = false; //disable further attacks
            StartCoroutine(disableAttack()); //start routine to disable the attacking flag, and enabling attack
        }
    }

    IEnumerator disableAttack()
    {
        yield return new WaitForSeconds(attack_duration); //once duration ends, reverse flags.
        attacking = false;
        canAttack = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
