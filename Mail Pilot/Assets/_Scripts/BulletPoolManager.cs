using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public static BulletPoolManager SharedInstance;
    public List<GameObject> pooledObjects;
    public int amountToPool;

    private void Awake()
    {

        SharedInstance = this;

    }

    //TODO: create a structure to contain a collection of bullets

    // Start is called before the first frame update
    void Start()
    {


        // TODO: add a series of bullets to the Bullet Pool
        _BuildBulletPool();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject tempBullet = null;

        if (!IsPoolEmpty())
        {
            tempBullet = pooledObjects[0];
            pooledObjects.Remove(tempBullet);
        }


        return tempBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        pooledObjects.Add(bullet);
        
    }

    private void _BuildBulletPool ()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bulletObj = (GameObject)Instantiate(bullet);
            bulletObj.transform.parent = this.transform;
            bulletObj.SetActive(false);
            pooledObjects.Add(bulletObj);
        }
        //Debug.Log(pooledObjects.Count);
    }

    public int GetPooledSize()
    {

        return pooledObjects.Count;
    }

    public bool IsPoolEmpty()
    {
        if (GetPooledSize() <= 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
