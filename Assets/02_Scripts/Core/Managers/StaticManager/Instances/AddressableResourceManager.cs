using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AddressableResourceManager : MonoBehaviour, IResourceManager
{

    [SerializeField] private List<AssetLabelReference> _firstLabel;

    private Dictionary<int, Object> _resourceContainer = new Dictionary<int, Object>();

    public void Init()
    {

        foreach (var label in _firstLabel)
        {

            var handle = Addressables.LoadResourceLocationsAsync(label);
            handle.Completed += HandleResourceLoaded;

        }

    }

    private void HandleResourceLoaded(AsyncOperationHandle<IList<IResourceLocation>> handle)
    {

        foreach (var data in handle.Result)
        {

            var h = Addressables.LoadAssetAsync<Object>(data);

            h.Completed += (res) =>
            {

                if (!_resourceContainer.ContainsKey(data.PrimaryKey.GetHash()))
                    _resourceContainer.Add(data.PrimaryKey.GetHash(), res.Result);
                else
                    Debug.LogWarning($"Key 중복을 발견 [Key = {data.PrimaryKey}]");


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


    public void Dispose()
    {
    }

}
