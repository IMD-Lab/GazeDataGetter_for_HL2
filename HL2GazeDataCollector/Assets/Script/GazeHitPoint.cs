using Microsoft.MixedReality.Toolkit;
using System;
using System.Net.Http;
using System.Text;
using UnityEngine;

public class GazeHitPoint : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();

    void Update()
    {
        var eyeGazeProvider = CoreServices.InputSystem?.EyeGazeProvider;

        if (eyeGazeProvider != null && eyeGazeProvider.IsEyeTrackingDataValid)
        {
            Ray gazeRay = new Ray(eyeGazeProvider.GazeOrigin, eyeGazeProvider.GazeDirection);

            if (Physics.Raycast(gazeRay, out RaycastHit hitInfo))
            {
                Vector3 hitPosition = hitInfo.point;
                Debug.Log("Gaze hit point: " + hitPosition);

                // ���÷���ע������ĺ���
                SendGazePosition(hitPosition);
            }
        }
    }

    private async void SendGazePosition(Vector3 gazePosition)
    {
        // ʹ�������ഴ�����ݽṹ
        var data = new GazeData
        {
            gaze_position = new GazePosition
            {
                x = gazePosition.x,
                y = gazePosition.y,
                z = gazePosition.z
            }
        };

        // ������ת��ΪJSON�ַ���
        string json = JsonUtility.ToJson(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync("http://163.221.38.221:5000/post_gaze", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log($"Server Response: {responseBody}");
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    // �������ݽṹ
    [Serializable]
    private class GazeData
    {
        public GazePosition gaze_position;
    }

    [Serializable]
    private class GazePosition
    {
        public float x;
        public float y;
        public float z;
    }
}
