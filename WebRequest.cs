using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour {
    public IEnumerator getRequest(string uri, System.Action<string> callback) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError) {
                callback("Error: " + webRequest.error);
                Debug.Log(callback);
                yield break;
            }

            callback(webRequest.downloadHandler.text);
        }
    }

    public IEnumerator PostRequest(string uri, string body, System.Action<string> callback) {
        var request = new UnityWebRequest(uri, "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(body);

        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError) {
            callback("Error: " + request.error);
            Debug.Log(callback);
            yield break;
        }

        callback(request.downloadHandler.text);
    }
}
