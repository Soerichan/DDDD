using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager :MonoBehaviour
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
        CreatePoolDic();
    }

    private void Start()
    {
       
    }

    private void OnEnable()
    {
        //StartCoroutine(DelayToReturn());
    }
   
    private IEnumerator DelayToReturn()
    {
        yield return new WaitForSeconds(m_fReturnTime);
        Release(gameObject);
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
        Stack<GameObject> stack =PoolDic[prefab.name];
        

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

    public GameObject Get(string name)
    {
        Stack<GameObject> stackCookie = PoolDic[name];


        if (stackCookie.Count > 0)
        {
            GameObject instanceCookie = stackCookie.Pop();
            instanceCookie.gameObject.SetActive(true);
            instanceCookie.transform.parent = null;
            return instanceCookie;
        }
        else
        {
            return null;
        }
    }

    public void Release(GameObject instance)
    {
        Stack<GameObject> stack = PoolDic[instance.name];
        instance.SetActive(false);
        PoolPrefab.Find(x=>name==x.Container.name);
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
