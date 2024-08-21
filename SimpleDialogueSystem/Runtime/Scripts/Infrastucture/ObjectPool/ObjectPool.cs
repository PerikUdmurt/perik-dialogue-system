using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private List<T> _objects = new List<T>();

        public ObjectPool(GameObject prefab, Transform parent ,int prepareObjects = 0)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < prepareObjects; i++)
            {
                Create();
            }
        }

        public void CleanUp()
        {
            foreach (var obj in _objects)
            {
                GameObject.Destroy(obj.gameObject);
            }
        }

        public T Get()
        {
            var obj = _objects.FirstOrDefault(x => x.gameObject.activeSelf == false);

            if (obj == null)
            {
                obj = Create();
            }
            obj.transform.SetParent(_parent);
            obj.gameObject.SetActive(true);
            return obj;
        }

        private T Create()
        {
            GameObject obj = GameObject.Instantiate(_prefab);
            T component = obj.GetComponent<T>();
            _objects.Add(component);
            component.gameObject.SetActive(false);
            return component;
        }

        public void Release(T obj)
        {
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(false);
        }
    }
}