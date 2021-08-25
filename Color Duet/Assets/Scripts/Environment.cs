using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public ParticleSystem redParticle;
    public ParticleSystem blueParticle;
    public GameObject spawnLocationBlue;
    public GameObject spawnLocationRed;

    public LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.collider.gameObject);
        if (gameObject.CompareTag("Spike"))
        {
            if (collision.gameObject.CompareTag("BlueBall"))
            {
                Instantiate(blueParticle, spawnLocationBlue.transform.position, Quaternion.identity);
                collision.gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("RedBall"))
            {
                Instantiate(redParticle, spawnLocationRed.transform.position, Quaternion.identity);
                collision.gameObject.SetActive(false);
            }
        }           

        if (gameObject.CompareTag("RecoverBall"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Instantiate(blueParticle, transform.position, Quaternion.identity);

            if (!levelManager.redBall.active)
            {
                levelManager.redBall.SetActive(true);
                //Instantiate(blueParticle, transform.position, Quaternion.identity);               
            }

            if (!levelManager.blueBall.active)
            {
                levelManager.blueBall.SetActive(true);
                //Instantiate(blueParticle, transform.position, Quaternion.identity);
            }
        }
    }
}
