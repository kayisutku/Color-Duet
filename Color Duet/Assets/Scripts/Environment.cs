using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public ParticleSystem upParticle;
    public ParticleSystem downParticle;
    public ParticleSystem recoverParticle;
    public GameObject spawnLocationDown;
    public GameObject spawnLocationUp;

    public LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Spike"))
        {
            if (collision.gameObject.CompareTag("Downball"))
            {
                Instantiate(downParticle, spawnLocationDown.transform.position, Quaternion.identity);
                collision.gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("UpBall"))
            {
                Instantiate(upParticle, spawnLocationUp.transform.position, Quaternion.identity);
                collision.gameObject.SetActive(false);
            }
        }          

        if (gameObject.CompareTag("RecoverBall"))
        {
            gameObject.SetActive(false);
            Instantiate(recoverParticle, transform.position, Quaternion.identity);

            if (!levelManager.upBall.active)
            {
                levelManager.upBall.SetActive(true);
                Instantiate(upParticle, spawnLocationUp.transform.position, Quaternion.identity);               
            }

            if (!levelManager.downBall.active)
            {
                levelManager.downBall.SetActive(true);
                Instantiate(downParticle, spawnLocationDown.transform.position, Quaternion.identity);
            }
        }
    }
}
