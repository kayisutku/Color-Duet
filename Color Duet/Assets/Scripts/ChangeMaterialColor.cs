using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] private Renderer ringMaterial;

    private BallColorController ballColorController;

    public Material[] material;

    private Environment environment;

    int counter = 0;

    private void Start()
    {
        ballColorController = GetComponent<BallColorController>();
        environment = GetComponent<Environment>();
        ringMaterial = GetComponent<Renderer>();
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
            ringMaterial.sharedMaterial = material[3];
            Instantiate(environment.redParticle, transform.position, Quaternion.identity);
            Instantiate(environment.blueParticle, transform.position, Quaternion.identity);
        }

        else if (other.CompareTag("RedBall"))
        {
            ringMaterial.sharedMaterial = material[1];
            Instantiate(environment.redParticle, transform.position, Quaternion.identity);
        }

        else if(other.CompareTag("BlueBall"))
        {
            ringMaterial.sharedMaterial = material[2];
            Instantiate(environment.blueParticle, transform.position, Quaternion.identity);
        }
    }
}
