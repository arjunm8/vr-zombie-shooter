using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class zombieScript : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    private kills killCount;


    void Start()
    {
        Application.targetFrameRate = 60;
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        GetComponent<Animation>().Play("walk");
        killCount = GameObject.FindWithTag("killCounter").GetComponent<kills>();
    }


    void OnTriggerEnter(Collider col)
    {
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(col.gameObject);
        agent.destination = gameObject.transform.position;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("back_fall");
        GetComponent<AudioSource>().Stop();
        killCount.killPlus();
        Destroy(gameObject, 6);
        GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

        float randomX = UnityEngine.Random.Range(-20f, 20f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-20f, 20f);
        zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 8)
        {

            randomX = UnityEngine.Random.Range(-20f, 20f);
            randomZ = UnityEngine.Random.Range(-20f, 20f);

            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }

    }
}
