using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int maxNumberOfAgents;
    [SerializeField] private GameObject objectPrefab;
    private List<GameObject> objectsList = new List<GameObject>();
    private int startingPoolCount = 5;
    private GetRandomSpotOnNavMesh getRandomSpot;

    private void Awake()
    {
        getRandomSpot = FindObjectOfType<GetRandomSpotOnNavMesh>();
    }


    private void Start()
    {
        for(int i = 0; i < startingPoolCount; i++)
        {
            CreateAndAddNewAgent();
        }
    }

    public GameObject GetAgent()
    {
        //Return inactive agent from pool
        for(int i = 0; i < objectsList.Count; i++)
        {
            if (!objectsList[i].activeInHierarchy)
            {
                return objectsList[i];
            }
        }

        //Create and return new agent
        if(objectsList.Count < maxNumberOfAgents)
        {
            return CreateAndAddNewAgent();
        }

        //Max numbers of agents
        return null;
    }

    private GameObject CreateAndAddNewAgent()
    {
        GameObject temp = Instantiate(objectPrefab, transform);
        temp.GetComponent<RandomMovementOfAgentOnNavMesh>().SetRandomMapController(getRandomSpot);
        temp.SetActive(false);
        objectsList.Add(temp);
        return temp;
    }
}
