using System.Collections.Generic;

public interface IFactory<T> : IFactoryable
{

    /// <summary>
    /// Key로 객체를 생성해준다
    /// </summary>
    /// <param name="data">객체 Key</param>
    /// <param name="extraData">보조 데이터</param>
    /// <returns></returns>
    public T CreateInstance(PrefabData data = default, object extraData = null);

}

public interface IFactoryable { }