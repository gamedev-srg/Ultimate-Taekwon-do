using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    Rigidbody rb;
    float duration = 4.5f;
    float knockback_mod = 20f;
    [SerializeField] Animator animator;
    [SerializeField] float maxHealth = 10;
    [SerializeField] float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void takeDamage(int damage) 
    {
        currentHealth -= damage;
        if(currentHealth <= 0) //if health is at 0, die.
        {
            Die(); 

        }
        else
        {
            //else if not dead, knock yourself back as to simulate being hit.
            rb.AddForce(Vector3.right *(knockback_mod*damage), ForceMode.Impulse);
        }

    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("GameOver");
    }
    void Die()
    {   //on death play death animation and exit game.
        animator.SetBool("Dead", true);
        StartCoroutine(EndGame());
    }
}
