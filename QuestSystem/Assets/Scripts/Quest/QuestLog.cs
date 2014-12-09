using UnityEngine;
using System.Collections;

public class QuestLog : MonoBehaviour {

	bool showLog,showDes;
	QuestsList Q_List;
	private Vector2 scrollPos = Vector2.zero;
	public GUIStyle buttonStyle;

	// Use this for initialization
	void Start () {
		Q_List = GetComponent<QuestsList> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.L))
		{
			ShowLog ();
		}
	}

	public void ShowLog()
	{
		showLog = !showLog;
	}

	void OnGUI()
	{
		buttonStyle = new GUIStyle();
		buttonStyle.fixedWidth = Screen.width/4.5f;
		buttonStyle.wordWrap = true;
		buttonStyle.normal.textColor = Color.white;	


		if(showLog == true)
		{
			GUI.BeginGroup (new Rect (Screen.width - Screen.width/3,Screen.height / 4f,Screen.width/3.5f,Screen.height/2), "","box");
			scrollPos = GUILayout.BeginScrollView(scrollPos,GUILayout.Width(Screen.width/4), GUILayout.Height(Screen.height/2));   
			
			
			for (int i = Q_List.Q_List.Count - 1; i >= 0; i--)
			{
				if(GUILayout.Button("Quest: " + Q_List.Q_List[i].Q_Name + "\n",buttonStyle))
				{
					Debug.Log(Q_List.Q_List[i].Q_Description);
					showDes = !showDes;	
				}

				if(showDes == true)
				{
					
					GUILayout.Label("Description: \n" + Q_List.Q_List[i].Q_Description + "\n");
					GUILayout.Label("Destination: " + Q_List.Q_List[i].Q_Destination + "\n");

					if(Q_List.Q_List[i].Q_Destination == gameObject.GetComponent<Destination>().destination)
					{						
						Q_List.Q_List[i].Q_Completed = true;
					}

					if(GUILayout.Button("Remove Quest"))
					{					
						Q_List.RemoveQuest(Q_List.Q_List[i]);
					}

					if(Q_List.Q_List.Count != 0)
					{
						if(Q_List.Q_List[i].Q_Completed == true)
						{
							Q_List.RemoveQuest(Q_List.Q_List[i]);
							Debug.Log("Quest completed");
								//Award Player etc..
						}
					}
					if(GUILayout.Button("Complete"))
					{
						Q_List.Q_List[i].Q_Completed = true;
					}
				}
			}
			
			GUILayout.EndScrollView();


			
			GUI.EndGroup ();
		}

	}
}
