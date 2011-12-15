using UnityEngine;
using System.Collections;

public abstract class Conversation {

	public abstract string GetText();
	public abstract Hashtable GetResponses();
	public abstract void Respond(Object response);
}
