﻿using UnityEngine;
using System.Collections;
using static Reward2D;

public class FPSDisplay : MonoBehaviour
{
	public static FPSDisplay FPScounter;
	public Reward2D reward;

	float deltaTime = 0.0f;
	public Transform target;
	public Camera cam;
	public float offset = 0.15f;
	public float fps;

	void Awake()
    {
		FPScounter = this;
    }

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		target.position = cam.transform.position + cam.transform.forward * offset;
		target.rotation = new Quaternion(0.0f, cam.transform.rotation.y, 0.0f, cam.transform.rotation.w);
		//print(Vector3.forward * offset);
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
		float msec = deltaTime * 1000.0f;
		fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)\nTrial Number: {2}\nPhase: {3}", msec, fps, reward.trialNum, SharedReward.GFFPhaseFlag);
		GUI.Label(rect, text, style);
	}

	public float GetFPS()
    {
		return fps;
    }
}