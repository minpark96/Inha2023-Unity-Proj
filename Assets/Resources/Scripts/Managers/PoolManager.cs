using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager
{
    #region Pool
    class Pool
    {
        static uint Count = 0;
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        List<Poolable> _poolableList = new List<Poolable>();
        Queue<uint> _idQueue = new Queue<uint>();

        public void Init(GameObject original, int count = 5)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = $"{original.name}_Root";

            for (int i = 0; i < count; i++)
                Push(Create());
        }

        Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            go.name = Original.name;
            return go.GetOrAddComponent<Poolable>();
        }

        public void Push(Poolable poolable)
        {
            if (poolable == null)
                return;

            poolable.transform.parent = Root;
            poolable.gameObject.SetActive(false);
            poolable.IsUsing = false;

            if (poolable.Id == 0)
            {
                poolable.Id = ++Count;
            }

            _idQueue.Enqueue(poolable.Id);
            _poolableList.Add(poolable);
        }

        public Poolable Pop(Transform parent)
        {
            Poolable poolable = null;

            if (_poolableList.Count > 0)
            {
                uint id = _idQueue.Dequeue();

                for (int i = 0; i < _poolableList.Count; i++)
                {
                    if (id == _poolableList[i].Id)
                    {
                        poolable = _poolableList[i];
                        _poolableList.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                poolable = Create();

                if (poolable.Id == 0)
                {
                    poolable.Id = ++Count;
                }
            }

            if (poolable != null)
            {
                poolable.gameObject.SetActive(true);

                // DontDestroyOnLoad 해제 용도
                if (parent == null)
                    poolable.transform.parent = GameObject.Find("@Managers").transform;

                poolable.transform.parent = parent;
                poolable.IsUsing = true;
            }

            return poolable;
        }
    }
    #endregion

    List<Pool> _poolList = new List<Pool>();
    List<string> _nameList = new List<string>();
    Transform _root;

    public void Init()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void CreatePool(GameObject original, int count = 5)
    {
        Pool pool = new Pool();
        pool.Init(original, count);
        pool.Root.parent = _root;

        _nameList.Add(original.name);
        _poolList.Add(pool);

        Debug.Log($"[PoolManager] Size : {count} -> {original} Pool 생성 ");
    }

    public void Push(Poolable poolable)
    {
        string name = poolable.gameObject.name;
        for (int i = 0; i < _nameList.Count; i++)
        {
            if (name == _nameList[i])
            {
                _poolList[i].Push(poolable);
                Debug.Log($"[PoolManager] ID : {poolable.Id} -> {name} Object 반환 ");
                return;
            }
        }

        GameObject.Destroy(poolable.gameObject);
    }

    public Poolable Pop(GameObject original, Transform parent = null)
    {
        Poolable poolable;

        int idx = 0;
        for (; idx < _nameList.Count; idx++)
        {
            if (original.name == _nameList[idx])
            {
                break;
            }
        }

        if (idx >= _nameList.Count)
        {
            CreatePool(original);
        }

        poolable = _poolList[idx].Pop(parent);
        Debug.Log($"[PoolManager] ID : {poolable.Id} -> {original.name} Object 스폰 ");
        return poolable;
    }

    public GameObject GetOriginal(string name)
    {
        for (int idx = 0; idx < _nameList.Count; idx++)
        {
            if (name == _nameList[idx])
            {
                return _poolList[idx].Original;
            }
        }

        return null;
    }

    public void Clear()
    {
        foreach (Transform child in _root)
            GameObject.Destroy(child.gameObject);

        _nameList.Clear();
        _poolList.Clear();
    }
}
