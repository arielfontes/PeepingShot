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

		System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/ScreenShots");
		Debug.Log(Application.persistentDataPath);
	}

	void Update () {
		exibeAlbum();
		controleFotosALbum();
	}

	/// <summary>
	/// carrega em um array todos os arquivos da pasta screenshot
	/// percorre o array transformando arquivos em Texture2D e guarda na IList fotos.
	/// 
	/// caso nao tenha foto, mostra para o jogador recurso "No Image Available"
	/// </summary>
	private void carregaFotos(){

		fotos = new List<Texture2D>();
		string[] aNomeFotos = Directory.GetFiles(Application.dataPath + "/ScreenShots", "*.png");
		try{
			foreach(string matFile in aNomeFotos){ 
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
			Debug.Log("nao tem imagem");
		}
	}

	private void exibeAlbum(){
		if (Input.GetKeyDown(KeyCode.M)){
			carregaFotos();
			cameraFPS.enabled = !cameraFPS.enabled;
			renderer.enabled = !renderer.enabled;
		}
	}

	/// <summary>
	/// Permite que o jogador avance e retorne fotos
	/// quando estiver vendo o album.
	/// Depois da ultima foto, volta para a primeira.
	/// </summary>
	private void controleFotosALbum(){
		try{
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
		}catch (ArgumentOutOfRangeException){
			//TODO disparar algum som ou outro feedback para o usuario, caso n tenha foto.
		}
	}
}
