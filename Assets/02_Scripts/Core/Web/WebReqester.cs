using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HttpRequestHeader = System.Net.Http.Headers.HttpRequestHeaders;

/// <summary>
/// 웹 응답을 표현하는 클래스
/// </summary>
public class WebResponse
{

    public HttpStatusCode statusCode;
    public string value;
    public bool isSuccess => statusCode == HttpStatusCode.OK;

}

/// <summary>
/// 웹 요청을 위한 커스텀 WebReqester
/// </summary>
public sealed class WebReqester : IDisposable
{

    private readonly HttpClient _client;
    public HttpContent content;
    public HttpRequestHeader header => _client.DefaultRequestHeaders;
    public string url;

    public WebReqester()
    {
        _client = new HttpClient();
    }

    private async Task<WebResponse> CreateWebResponse(HttpResponseMessage response)
    {

        var rep = new WebResponse();
        rep.statusCode = response.StatusCode;
        rep.value = await response.Content.ReadAsStringAsync();

        return rep;
    }

    public async Task<WebResponse> PostAsync()
    {

        var response = await _client.PostAsync(url, content);

        return  await CreateWebResponse(response);

    }

    public async Task<WebResponse> GetAsync()
    {

        var response = await _client.GetAsync(url);

        return await CreateWebResponse(response);

    }

    public void Dispose()
    {
        _client.Dispose();
    }

}