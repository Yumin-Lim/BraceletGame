using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;


public class Capture : MonoBehaviour
{
    public static Capture Instance;
    public string fileName;
    public Camera subCamera;

    public void Awake()
    {
        Instance = this;
    }

    //팔찌가 다 만들어졌을때 capture ㅁ컴포넌트 onCapture 함수 호출
    public void OnCapture(string fName, Action endCallback)

    {
        Debug.Log("Capture onCapture() fName" + fName);
        fileName = fName;
        StartCoroutine(CaptureScreen(fName, endCallback));
    }


    IEnumerator CaptureScreen(string name, Action endCallback)
    {
        yield return new WaitForEndOfFrame();

        // 화면 크기 가져오기
        int width = subCamera.targetTexture.width;
        int height = subCamera.targetTexture.height;

        // RenderTexture 생성
        RenderTexture rt = new RenderTexture(width, height, 24);
        subCamera.targetTexture = rt;
        subCamera.Render();

        // Texture2D로 변환
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGBA32, false);
        RenderTexture.active = subCamera.targetTexture;
        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenshot.Apply();

        // 파일 저장
#if UNITY_EDITOR
        //유니티에디터에서 써야되는 코드
        string directory = Path.Combine(Application.dataPath, "Capture");

#else
        //빌드된 다른 플랫폼에서 써야되는 코드
        string directory = Path.Combine(Application.persistentDataPath, "Capture");
#endif
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string fileName = $"{name}.png";
        string filePath = Path.Combine(directory, fileName);

        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
        endCallback.Invoke();
    }


    public static Sprite LoadSpriteFromFile(string fileName)
    {
#if UNITY_EDITOR
        //유니티에디터에서 써야되는 코드
        string directory = Path.Combine(Application.dataPath, "Capture");

#else
        //빌드된 다른 플랫폼에서 써야되는 코드
        string directory = Path.Combine(Application.persistentDataPath, "Capture");
#endif
        string filePath = Path.Combine(directory, fileName + ".png");

        if (!File.Exists(filePath))
        {
            Debug.LogError($"파일을 찾을 수 없습니다: {filePath}");
            return null;
        }

        // 파일을 바이트 배열로 읽기
        byte[] fileData = File.ReadAllBytes(filePath);

        // Texture2D 생성
        Texture2D texture = new Texture2D(2, 2);

        // 이미지 데이터 로드
        if (texture.LoadImage(fileData))
        {
            // Sprite 생성
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        else
        {
            Debug.LogError($"이미지 로드 실패: {filePath}");
            return null;
        }
    }

    public static void Delete(string fName)
    {
#if UNITY_EDITOR
        //유니티에디터에서 써야되는 코드
        string directory = Path.Combine(Application.dataPath, "Capture");

#else
        //빌드된 다른 플랫폼에서 써야되는 코드
        string directory = Path.Combine(Application.persistentDataPath, "Capture");
#endif
        string filePath = Path.Combine(directory, fName + ".png");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}