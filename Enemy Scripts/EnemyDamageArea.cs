using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{

    [SerializeField]

    private float deactivateWaitTime = 0.1f;
    private float deactivateTimer;

    [SerializeField]
    private LayerMask playerLayer;

    private bool canDealDamage;

    [SerializeField]
    private float damageAmount =5f;




    /// <summary>
    /// Player Health
    /// </summary>


    private PlayerHealth playerHealth;



    private void Awake()
    {

        playerHealth = GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<PlayerHealth>();  
        gameObject.SetActive(false);
    }



    private void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 1f, playerLayer))
        {
            //Debug.Log("Deal damage to player");

            if (canDealDamage)
            {
                canDealDamage = false;
                //deal damage to player
                //Debug.Log("Damaged Player");

                playerHealth.TakeDamage(damageAmount);
            
            }
             
        }
        DeactivateDamageArea();
    }


    void DeactivateDamageArea()
    {
        if (Time.time > deactivateTimer)
            gameObject.SetActive(false);
    }


    public void ResetDeactivateTimer()
    {
        canDealDamage = true;
        deactivateTimer = Time.time + deactivateWaitTime;
    }


}//////////
