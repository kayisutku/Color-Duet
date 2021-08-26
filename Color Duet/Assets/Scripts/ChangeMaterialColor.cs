using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] private Renderer ringMaterial;

    private BallColorController ballColorController;
    [SerializeField] Color ringColorMix;
    [SerializeField] Color ringColorBlue;
    [SerializeField] Color ringColorRed;

    public Material[] material;

    private Environment environment;

    int counter = 0;

    private void Start()
    {
        ballColorController = GetComponent<BallColorController>();
        environment = GetComponent<Environment>();
        ringMaterial = GetComponent<Renderer>();
        ringMaterial.material.color = Color.green;

        ringMaterial.sharedMaterial = material[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("BlueBall") || other.CompareTag("RedBall"))
        {
            counter++;
        }

        if(counter == 2)
        {
            //ringMaterial.material.color = Color.yellow;
            //ringMaterial.material.SetColor("_ringColorMix", ringColorMix);
            ringMaterial.sharedMaterial = material[3];

            /*Instantiate(environment.redParticle, environment.spawnLocationRed.transform.position, Quaternion.identity);
            Instantiate(environment.blueParticle, environment.spawnLocationBlue.transform.position, Quaternion.identity);*/

            Instantiate(environment.redParticle, transform.position, Quaternion.identity);
            Instantiate(environment.blueParticle, transform.position, Quaternion.identity);

            Debug.Log("purple");
        }

        else if (other.CompareTag("RedBall"))
        {
            //ringMaterial.material.color = Color.red;
            //ringMaterial.material.SetColor("_ringColorRed", ringColorRed);
            ringMaterial.sharedMaterial = material[1];

            //Instantiate(environment.redParticle, environment.spawnLocationRed.transform.position, Quaternion.identity);
            Instantiate(environment.redParticle, transform.position, Quaternion.identity);

            Debug.Log("red");
        }

        else if(other.CompareTag("BlueBall"))
        {
            //ringMaterial.material.color = Color.blue;
            //ringMaterial.material.SetColor("_ringColorBlue", ringColorBlue);
            ringMaterial.sharedMaterial = material[2];

            //Instantiate(environment.blueParticle, environment.spawnLocationBlue.transform.position, Quaternion.identity);
            Instantiate(environment.blueParticle, transform.position, Quaternion.identity);

            Debug.Log("blue");
        }
    }
}
