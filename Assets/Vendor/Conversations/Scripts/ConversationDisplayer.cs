using UnityEngine;
using System.Collections;

public class ConversationDisplayer : MonoBehaviour {
	
	public int height = 500;
	public int width = 300;
	
	private Conversation conversation;
	
	void OnGUI(){
		if(conversation == null)
			return;
		
		GUIStyle guiStyle = GUI.skin.box;
		guiStyle.wordWrap = true;
		guiStyle.font = GUI.skin.font;
		
		GUI.Box(new Rect(Screen.width/2-width/2,Screen.height/2-height/2,width,height), conversation.GetText(), guiStyle);
		
		int response_height = 0;
		foreach(DictionaryEntry response in conversation.GetResponses())
		{
			string response_text = response.Value as string;
			if(GUI.Button(new Rect(Screen.width/2+width/2 + 10,Screen.height/2-height/2 + response_height,200,50), response_text))
			{
				conversation.Respond(response.Key as Object);
			}
			response_height += 60;
		}
		
		if(GUI.Button(new Rect(Screen.width/2+width/2 + 10,Screen.height/2-height/2 + response_height,200,50), "(Exit)"))
		{
			conversation = null;
		}
	}
	
	public void Initiate(Conversation conversation)
	{
		this.conversation = conversation;
	}
}
