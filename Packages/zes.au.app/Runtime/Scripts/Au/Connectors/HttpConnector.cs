using Au.TS;
using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Au.Connectors
{
    [JSWrap]
    /// <summary>
    /// Http Connector
    /// </summary>
    public class HttpConnector
    {
        private Log log = Log.GetLogger<HttpConnector>();

        /// <summary>
        /// Create a new http connector
        /// </summary>
        /// <param name="baseUrl">base url like 'http://www.xxx.com/'</param>
        public HttpConnector(string baseUrl)
        {
            this.baseUrl = baseUrl;
            if (!this.baseUrl.EndsWith("/"))
            {
                this.baseUrl += "/";
            }
        }

        /// <summary>
        /// Base url
        /// </summary>
        public readonly string baseUrl;

        private string token = null;

        /// <summary>
        /// Set the auth token for connector
        /// </summary>
        /// <param name="token"></param>
        public void SetToken(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// Send get request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<HttpResult> Get(string url)
        {
            url = GetFullUrl(url);
            using (var www = UnityWebRequest.Get(url))
            {
                www.downloadHandler = new DownloadHandlerBuffer();
                SetHeads(www);
                var op = www.SendWebRequest();
                await Utils.WaitAsyncOperation(op);
                if (www.result != UnityWebRequest.Result.Success)
                {
                    log.Error($"Get {www.url} failed: \n({www.responseCode}) {www.error})");
                    int code = (int)(www.responseCode == 0 ? 500 : www.responseCode);
                    return new HttpResult(code, www.error);
                }
                string str = www.downloadHandler.text;
                return new HttpResult(str);
            }
        }

        /// <summary>
        /// Send post request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<HttpResult> Post(string url, string json)
        {
            url = GetFullUrl(url);
            using (var www = new UnityWebRequest(url, "POST"))
            {
                www.downloadHandler = new DownloadHandlerBuffer();
                if (!string.IsNullOrEmpty(json))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(json);
                    www.uploadHandler = new UploadHandlerRaw(bytes);
                    www.SetRequestHeader("Content-Type", "application/json");
                }
                SetHeads(www);
                var op = www.SendWebRequest();
                await Utils.WaitAsyncOperation(op);
                if (www.result != UnityWebRequest.Result.Success)
                {
                    log.Error($"Post {www.url} failed: \n({www.responseCode}) {www.error})");
                    int code = (int)(www.responseCode == 0 ? 500 : www.responseCode);
                    return new HttpResult(code, www.error);
                }

                string str = www.downloadHandler.text;
                return new HttpResult(str);
            }
        }

        /// <summary>
        /// Download file to target
        /// </summary>
        /// <param name="url"></param>
        /// <param name="targetPath"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<bool> Download(string url, string targetPath, Action<float> progress)
        {
            url = GetFullUrl(url);
            using (var www = UnityWebRequest.Get(url))
            {
                www.downloadHandler = new DownloadHandlerFile(targetPath);
                var webreq = www.SendWebRequest();
                while (!webreq.isDone)
                {
                    progress?.Invoke(webreq.progress);
                    await Task.Yield();
                }
                progress?.Invoke(1);

                if (www.result != UnityWebRequest.Result.Success)
                {
                    log.Error($"Download {www.url} failed: \n({www.responseCode}) {www.error})");
                    return false;
                }

                return www.result == UnityWebRequest.Result.Success;
            }

        }

        private void SetHeads(UnityWebRequest www)
        {
            if (!string.IsNullOrEmpty(token))
            {
                www.SetRequestHeader("Authorization", $"Bearer {token}");
            }
        }

        private string GetFullUrl(string url)
        {
            if (url.StartsWith("/"))
            {
                url = url.Substring(1);
            }
            return baseUrl + url;
        }

    }
}
