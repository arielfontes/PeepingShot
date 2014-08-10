using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class AlbumFotos : MonoBehaviour {

	private IList<Texture2D> fotos;
	private int listaIndex = 1;
	public Camera camera;
	
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
		string[] aNomeFotos = Directory.GetFiles("Assets/ScreenShots", "*.png", SearchOption.AllDirectories);
		foreach(string matFile in aNomeFotos){
			string assetPath = matFile.Replace("Assets/ScreenShots/", "").Replace('\\', '/');
			Texture2D sourceMat = (Texture2D)AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture2D));
			fotos.Add(sourceMat);
		}
		renderer.material.mainTexture = fotos[0];
	}

	private void exibeAlbum(){
		if (Input.GetKeyDown(KeyCode.M)){
			camera.enabled = !camera.enabled;
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
