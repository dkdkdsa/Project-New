using System;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// 웹 요청을 위한 커스텀 WebReqester
/// </summary>
public sealed class WebReqester : IDisposable
{

    private readonly HttpClient _client;
    public HttpContent content;
    public string url;

    public WebReqester()
    {
        _client = new HttpClient();
    }

    public async Task<string> PostAsync()
    {

        var response = await _client.PostAsync(url, content);

        return await response.Content.ReadAsStringAsync();

    }

    public async Task<string> GetAsync()
    {

        var response = await _client.GetAsync(url);

        return await response.Content.ReadAsStringAsync();

    }

    public void Dispose()
    {
        _client.Dispose();
    }

}