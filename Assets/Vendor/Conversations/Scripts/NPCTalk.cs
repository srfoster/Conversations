using UnityEngine;
using System.Collections;

public class NPCTalk : MonoBehaviour {
	
	private bool talked = false; 
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		Debug.Log(Vector3.Distance(transform.position, player.transform.position));
		
		if(Vector3.Distance(transform.position, player.transform.position) <= 3 && !talked)
		{
			talked = true;
			ConversationDisplayer c = GameObject.Find("ConversationDisplayer").GetComponent(typeof(ConversationDisplayer)) as ConversationDisplayer;
			c.Initiate(new ExampleConversation());
		}
	}
}
