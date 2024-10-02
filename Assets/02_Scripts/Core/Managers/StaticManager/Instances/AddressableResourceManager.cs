using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AddressableResourceManager : MonoBehaviour, IResourceManager
{

    private Dictionary<int, Object> _resourceContainer = new Dictionary<int, Object>();
    private Dictionary<int, List<ResourceMap<Object>>> _resourceByLabel = new Dictionary<int, List<ResourceMap<Object>>>();

    public void Init()
    {

        var firstLabels = Resources.Load<FirstLoadDataSO>("FirstLoad").labels;

        foreach (var label in firstLabels)
        {

            var handle = Addressables.LoadResourceLocationsAsync(label);
            handle.Completed += (hanedle) => 
            {

                foreach (var data in handle.Result)
                {

                    var h = Addressables.LoadAssetAsync<Object>(data);

                    h.Completed += (res) =>
                    {

                        if (!_resourceContainer.ContainsKey(data.PrimaryKey.GetHash()))
                        {

                            _resourceContainer.Add(data.PrimaryKey.GetHash(), res.Result);

                        }

                        if(!_resourceByLabel.ContainsKey(label.labelString.GetHash()))
                            _resourceByLabel.Add(label.labelString.GetHash(), new());

                        _resourceByLabel[label.labelString.GetHash()].Add(new ResourceMap<Object> 
                        { data = res.Result, key = data.PrimaryKey });


                    };

                }

            };

        }

    }        

    public T GetResource<T>(string key) where T : Object
    {
        return _resourceContainer[key.GetHash()] as T;
    }

    public T GetResource<T>(int key) where T : Object
    {
        return _resourceContainer[key] as T;
    }


    public IReadOnlyList<ResourceMap<T>> GetResources<T>(string key) where T : Object
    {

        return GetResources<T>(key.GetHash());

    }

    public IReadOnlyList<ResourceMap<T>> GetResources<T>(int key) where T : Object
    {

        var list = _resourceByLabel[key];

        List<ResourceMap<T>> res = new List<ResourceMap<T>>();

        foreach(var item in list)
        {

            res.Add(new ResourceMap<T> { data = item as T, key = item.key });

        }

        return res;

    }


    public void Dispose()
    {
        _resourceContainer.Clear();
    }


}
