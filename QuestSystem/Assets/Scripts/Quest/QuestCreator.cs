using UnityEngine;
using System.Collections;

public class QuestCreator : MonoBehaviour {

	public string Q_Name, Q_Description;
	public int Q_Objective;
	QuestsList Q_List;
	Quests N_Quest;
	bool show;
	GameObject[] places;
	int p = 0;
	float Border_width, Border_height, G_width, G_height;
	// Use this for initialization
	void Start () {
		Q_List = GetComponent<QuestsList> ();
		places = GameObject.FindGameObjectsWithTag ("Places");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K))
		{
			ShowCreator ();
		}

		Border_width = Screen.width/3f;
		Border_height = Screen.height / 4f;
		G_width = Screen.width/3.5f;
		G_height = Screen.height/2;
	}

	public void ShowCreator()
	{
		show = !show;
	}

	void OnGUI()
	{

		if(show == true)
		{
			GUI.BeginGroup (new Rect (Border_width,Border_height,G_width,G_height), "","box");
				
			Q_Name = GUI.TextField (new Rect (10, Border_height / 20, G_width - 20, G_height / 15), Q_Name, 25);
				
				
			Q_Description = GUI.TextArea (new Rect (10, Border_height / 4.5f, G_width - 20, G_height / 2), Q_Description);
				
			if(GUI.Button(new Rect(10,Border_height + Border_height /3,G_width /5,G_height / 15),"<-"))
				{
					if(p > 0)
					{
						p--;
					}
				}
				
			GUI.Label(new Rect(Border_width / 3f,Border_height + Border_height /3 ,G_width /5,G_height / 15),"" + places[p].name,"box");
				
			if(GUI.Button(new Rect(Border_width / 1.5f ,Border_height + Border_height /3,G_width /5,G_height / 15),"->"))
				{
					if(p < places.Length -1)
					{
						p++;
					}
				}
				
			if(GUI.Button (new Rect (Border_width / 3.5f,Border_height + Border_height /1.5f ,G_width /3,G_height / 10), "Set Quest"))
				{	
					N_Quest = new Quests();
					N_Quest.Q_Name = Q_Name;
					N_Quest.Q_Description = Q_Description;
					N_Quest.Q_Destination = places[p].name;
					Q_List.AddQuest(N_Quest);
					Q_Name = "";
					Q_Description = "";
				}
				
			GUI.EndGroup();
				
			}

		}

}


