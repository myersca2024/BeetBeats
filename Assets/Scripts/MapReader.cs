using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReader : MonoBehaviour
{
    public string fileName;
    public BeetKeyframe[] keyframes;

    private Composer composer;

    private void Awake()
    {
        composer = GetComponent<Composer>();
        string path = Application.streamingAssetsPath + "/" + fileName;
        string[] keyframes = System.IO.File.ReadAllLines(@path);
        composer.songBpm = float.Parse(keyframes[0]);
        ParseKeyframes(keyframes);
    }

    private void ParseKeyframes(string[] keyframes)
    {
        // Initialize list
        List<BeetKeyframe> readFrames = new List<BeetKeyframe>();

        // If the file has more than a BPM
        if (keyframes.Length > 1)
        {
            string[] keyframe = new string[3];
            for (int i = 1; i < keyframes.Length; i++)
            {
                keyframe = keyframes[i].Split(' ');
                BeetKeyframe frame;
                frame.beat = float.Parse(keyframe[0]);
                frame.type = int.Parse(keyframe[1]) == 0 ? KeyframeType.Farm : KeyframeType.Cutting;
                frame.val  = int.Parse(keyframe[2]);
                readFrames.Add(frame);
                Debug.Log(frame.ToString());
            }
        }

        this.keyframes = readFrames.ToArray();
    }
}

public enum KeyframeType
{
    Farm,
    Cutting
}

public struct BeetKeyframe
{
    public float beat;
    public KeyframeType type;
    public int val;
}