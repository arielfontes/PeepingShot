using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Collections.Generic;
using System;

public class AlbumFotos : MonoBehaviour {

	private IList<Texture2D> fotos;
	private int listaIndex = 1;
	public Camera cameraFPS;
	
	void Start () {
		renderer.enabled = false;
		carregaFotos();
	}
	
	// Update is called once per frame
	void Update () {
		exibeAlbum();
		controleFotosALbum();
	}

	private void carregaFotos(){
		fotos = new List<Texture2D>();
		string[] aNomeFotos = Directory.GetFiles("Assets/ScreenShots", "*.png");
		foreach(string matFile in aNomeFotos){
			string assetPath = matFile.Replace("Assets/ScreenShots/", "").Replace('\\', '/');
			Texture2D sourceMat = (Texture2D)AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture2D));
			fotos.Add(sourceMat);
		}
		try{
			renderer.material.mainTexture = fotos[0];
			Debug.Log("fotos][0");
		}catch (ArgumentOutOfRangeException){
			Texture2D sourceMat = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/ScreenShots/noImage/noImageAvailable.png", typeof(Texture2D));
			renderer.material.mainTexture = sourceMat;
			Debug.Log("catch");
		}
	}

	private void exibeAlbum(){
		if (Input.GetKeyDown(KeyCode.M)){
			carregaFotos();
			cameraFPS.enabled = !cameraFPS.enabled;
			renderer.enabled = !renderer.enabled;
		}
	}

	private void controleFotosALbum(){
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			if (listaIndex >= fotos.Count){
				listaIndex = 0;
			}
			renderer.material.mainTexture = fotos[listaIndex++];
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			listaIndex--;
			if (listaIndex < 0){
				listaIndex = fotos.Count -1;
			}
			renderer.material.mainTexture = fotos[listaIndex];
		}
	}
}
