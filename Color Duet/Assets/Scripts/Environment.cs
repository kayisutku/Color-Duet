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
        RecoverBall();

        //Destroy(collision.collider.gameObject);
        collision.gameObject.SetActive(false);

        if (collision.gameObject.CompareTag("BlueBall"))
        {
            Instantiate(blueParticle, spawnLocationBlue.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("RedBall"))
        {
            Instantiate(redParticle, spawnLocationRed.transform.position, Quaternion.identity);
        }

        /*if (gameObject.CompareTag("BlueBall") && !levelManager.redBall.active)
        {
            levelManager.redBall.SetActive(true);
            Instantiate(blueParticle, transform.position, Quaternion.identity);
        }

        if (gameObject.CompareTag("redBall") && !levelManager.blueBall.active)
        {
            levelManager.blueBall.SetActive(true);
            Instantiate(blueParticle, transform.position, Quaternion.identity);
        }*/

    }

    public void RecoverBall()
    {
        if(gameObject.CompareTag("RecoverBall") && !levelManager.redBall.active)
        {
            levelManager.redBall.SetActive(true);
            Instantiate(blueParticle, transform.position, Quaternion.identity);
        }

        if(gameObject.CompareTag("RecoverBall") && !levelManager.blueBall.active)
        {
            levelManager.blueBall.SetActive(true);
            Instantiate(blueParticle, transform.position, Quaternion.identity);
        }
    }
}
