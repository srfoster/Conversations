using UnityEngine;
using System.Collections;

/*
 * Current gnome's conversation protocal
 */
public class NPCTalk : MonoBehaviour {
	private Conversation convo = null;
	private bool talked = false; 
	
	void OnTriggerEnter (Collider collider) {
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if(collider.gameObject != player)
			return;
				

		// Initialize a conversation if one hasn't started yet
		if(!talked)
		{
			talked = true;
			convo = new GraphConversation();
		}
		ConversationDisplayer c = GameObject.Find("ConversationDisplayer").GetComponent(typeof(ConversationDisplayer)) as ConversationDisplayer;
		c.Converse(convo);
		
	}
	
	void OnTriggerExit (Collider collider) {
				
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if(collider.gameObject != player)
			return;
		
		ConversationDisplayer c = GameObject.Find("ConversationDisplayer").GetComponent(typeof(ConversationDisplayer)) as ConversationDisplayer;
		c.Converse(null);
	}
}
