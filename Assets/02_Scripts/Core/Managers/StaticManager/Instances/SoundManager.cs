using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : ISoundManager
{

    private Dictionary<Guid, AudioSource> _playContainer = new();
    private IResourceManager _resourceManager;

    public void Init()
    {

        _resourceManager = Managers.GetManager<IResourceManager>();

    }

    public Guid PlaySound(string soundKey, float volume, bool loop = false, SoundPlayType type = SoundPlayType.Play2D)
    {

        AudioClip clip = _resourceManager.GetResource<AudioClip>(soundKey);
        Guid key = Guid.NewGuid();



        return key;

    }

    public bool StopSound(Guid soundKey)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {


    }

}
