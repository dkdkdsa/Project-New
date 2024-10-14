using System;
using System.Threading.Tasks;

public interface IUserControlManager : IManager
{

    public IUser User { get; }

    /// <summary>
    /// 유저를 생성함
    /// </summary>
    public Task<bool> CreateUser();


    /// <summary>
    /// 유저 정보를 초기화
    /// </summary>
    public Task<bool> UpdateUser();

}
