using UnityEngine;
using System.Collections;

public class ExampleConversation : Conversation {
	
	private int state = 0;
	private string salutation = "Hello.  This is an example of a conversation.  How are you?";
	private string goodbye    = "Goodbye.  You should subclass Conversation and make a better conversation class than this.";

	public override string GetText(){
		if(state == 0)
			return salutation;
		
		return goodbye;
	}
	
	public override Hashtable GetResponses(){
		Hashtable hash = new Hashtable();

		if(state == 0)
		{
			hash.Add(1, "I'm good.");
			hash.Add(2, "I'm having a bad day.");
			hash.Add(3, "Terrible.");
			
			return hash;
		} else {
			return hash;
		}
	}
	
	public override void Respond(Object response){
		state = 1;
	}
}
