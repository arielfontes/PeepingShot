using UnityEngine;
using System.Collections;
using System.IO;
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
		string[] aNomeFotos = Directory.GetFiles(Application.dataPath + "/ScreenShots", "*.png");
		try{
			foreach(string matFile in aNomeFotos){ 
				// original
//				string assetPath = matFile.Replace("Assets/ScreenShots/", "").Replace('\\', '/');
				// teste
				string assetPath = matFile.Replace(Application.dataPath + "/screenshots/", "").Replace('\\', '/');
				byte[] sourceBytes = System.IO.File.ReadAllBytes(assetPath);
				Texture2D tex = new Texture2D(4,4);
				tex.LoadImage(sourceBytes);
				fotos.Add(tex);
			}

			renderer.material.mainTexture = fotos[0];
			Debug.Log("fotos][0");
		}catch (ArgumentOutOfRangeException){
			renderer.material.mainTexture = (Texture2D)Resources.Load("noImageAvailable", typeof(Texture2D));
			Debug.Log("catch");
		}
	}

	private void exibeAlbum(){
		if (Input.GetKeyDown(KeyCode.M)){
			Debug.Log("MMM");
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
