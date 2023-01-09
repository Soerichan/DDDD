using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{

    [SerializeField]
    private float m_fReturnTime;

    //[SerializeField]
    private Dictionary<string, Stack<GameObject>> PoolDic;

    [SerializeField]
    private List<PoolableObject> PoolPrefab;

    private void Awake()
    {
        PoolDic=new Dictionary<string, Stack<GameObject>>();
       
    }

    private void Start()
    {
        CreatePoolDic();
    }

    private void OnEnable()
    {
        StartCoroutine(DelayToReturn());
    }
   
    private IEnumerator DelayToReturn()
    {
        yield return new WaitForSeconds(m_fReturnTime);
        PoolManager.Instance.Release(gameObject);
    }

    private void CreatePoolDic()
    {
        for(int a=0; a < PoolPrefab.Count; a++)
        {
            Stack<GameObject> stack = new Stack<GameObject>();

            for(int b=0; b < PoolPrefab[a].Count;b++)
            {
                GameObject instance = Instantiate(PoolPrefab[a].Prefab);
                instance.SetActive(false);
                instance.transform.parent= PoolPrefab[a].Container;
                instance.name = PoolPrefab[a].Container.name;
                
                stack.Push(instance);
            }
            PoolDic.Add(PoolPrefab[a].Prefab.name, stack);
        }
    }

    public GameObject Get(GameObject prefab)
    {
        Stack<GameObject> stack = new Stack<GameObject>();
        stack = PoolDic[prefab.name];

        if(stack.Count>0)
        {
            GameObject instance= stack.Pop();
            instance.gameObject.SetActive(true);
            instance.transform.parent = null;
            return instance;
        }
        else
        {
            return null;
        }

    }

    private void Release(GameObject instance)
    {
        Stack<GameObject> stack = new Stack<GameObject>();
        stack = PoolDic[instance.name];
        instance.SetActive(false);
        PoolPrefab.Find(x=>Instance.name==x.Container.name);
        stack.Push(instance);
    }

    [Serializable]
    struct PoolableObject
    {
        public GameObject Prefab;
        public int Count;
        public Transform Container; 
       // public string name;
    }
}
