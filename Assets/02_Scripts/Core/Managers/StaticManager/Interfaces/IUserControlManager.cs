using System;
using System.Threading.Tasks;

public interface IUserControlManager : IManager
{

    /// <summary>
    /// 유저를 생성함
    /// </summary>
    public Task<IUser> CreateUser(Action<IUser> createdCallback);


    /// <summary>
    /// 유저 정보를 초기화
    /// </summary>
    public Task<bool> UpdateUser();

}
