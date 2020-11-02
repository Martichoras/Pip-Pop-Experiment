using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataLogging : MonoBehaviour {

	private GameObject scriptholder;
	private StreamWriter stream_writer;
	public int prevScene;
	private Scene scene;
	private string path;
	static string name;
	private bool onceOnly = false;
	private bool onceOnly2 = false;
	private GameObject tmp;
	private string tmpStr;

	// logging components
	private string ID;
	private float currentTime;
	private float setSize;

	//
	private GameObject[] getCount;
	private int dupCount;

	void Awake(){

		DontDestroyOnLoad(this);

		//getCount = GameObject.FindGameObjectsWithTag("Datalog");
		//if(getCount.Length > 1)
		//{
	//		Destroy(this);
	//	}


	}

	void Start(){

		//DontDestroyOnLoad(this);

		scriptholder = GameObject.Find("Scriptholder");

		// Make folder Datalog in directory if it does not exist
		if (!Directory.Exists("Datalog"))
		{
			Directory.CreateDirectory("Datalog");
		}
		path = Directory.GetCurrentDirectory(); // stores directory location in 'path'

	}

	void Update(){

		scene = SceneManager.GetActiveScene();
		//Debug.Log("SCENE: "+scene.name);
		//ID = scriptholder.GetComponent<MainManager>().participantID;
		if(scene.buildIndex != 0 ){
		ID = SetID();
		}

		if(ID != null){
			//ID = SetID();
			if (!Directory.Exists("Datalog/"+ID))
			{
				Directory.CreateDirectory("Datalog/"+ID);
			}
			if(scene.buildIndex == 1 || scene.buildIndex == 2 || scene.buildIndex == 3){
				if(!onceOnly){
					
					prevScene = scene.buildIndex;
					Debug.Log("prevScene = "+prevScene);
					name = GetSceneName(prevScene);
					Debug.Log("Scene name= "+name);
					onceOnly = true;
				}
			}
		}

		if(scene.buildIndex == 4){
			if(!onceOnly2){
				setSize = scriptholder.GetComponent<MainManager>().pinAmount;
				currentTime = scriptholder.GetComponent<MainManager>().GetTCT();
				//stream_writer = new StreamWriter (path+"/Datalog/"+ID+"/"+System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss")+" - P"+ID+".txt",true);
				stream_writer = new StreamWriter (path+"/Datalog/"+ID+"/P"+ID+".txt",true);
				stream_writer.Close();
				//stream_writer.Write(name+","+setSize+","+currentTime.ToString()+"\n");
				//stream_writer.Close();
				onceOnly2 = true;
			}
		}
	}

	public string GetSceneName(int idx){
		string name;
		if(idx == 1){
			name = "NoSound";
		} else if(idx == 2){
			name = "Stereo";
		} else if(idx == 3){
			name = "Binaural";
		} else {
			name = "Error";
		}

		return name;
	}

	public void NewTrial(){
		stream_writer = new StreamWriter (path+"/Datalog/"+ID+"/P"+ID+".txt",true);
		stream_writer.Write(name+","+setSize+","+currentTime.ToString()+"\n");
		stream_writer.Close();
		SceneManager.LoadScene(0);
		onceOnly = false;
		onceOnly2 = false;

		scriptholder.GetComponent<MainManager>().savedID = ID;

		//stream_writer.Write("\n--- New trial ---");

	}

	public void NewTest(){
		stream_writer = new StreamWriter (path+"/Datalog/"+ID+"/P"+ID+".txt",true);
		stream_writer.Write(name+","+setSize+","+currentTime.ToString()+"\n");
		stream_writer.WriteLine("\n--- Ending test ---");
		stream_writer.Close();
		//Application.LoadLevel("1_Main");
		SceneManager.LoadScene(0);
		onceOnly = false;
		scriptholder.GetComponent<MainManager>().participantID = null;
		ID = null;

		//	scriptholder.GetComponent<MainManager>().savedID = null;

	}

	public void Quit(){
		stream_writer = new StreamWriter (path+"/Datalog/"+ID+"/P"+ID+".txt",true);
		stream_writer.Write(name+","+setSize+","+currentTime.ToString()+"\n");
		stream_writer.Write("\n--- Ending test ---");
		stream_writer.Close();
		Application.Quit();
	}

	public void OnApplicationQuit(){
		//stream_writer.WriteLine(name+","+setSize+","+currentTime.ToString()+"\n");
		//stream_writer.WriteLine("\n Ending test");
		//stream_writer.Write("9,-1,-1,"+Time.time+"\r\n");
		//stream_writer.Close ();
	}

	public string SetID (){
		string id;
		id = scriptholder.GetComponent<MainManager>().participantID;
		if(id != null){
		return id;
		} else return null;
	}

	public string GetID (){

		return ID;
	}

}
