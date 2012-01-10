using UnityEngine;
using System.Collections;

public class Node {
	string statement = null;
	ArrayList responses = null;
	Response exitResponse;
	
	public Node (string p_statement)
	{
		statement = p_statement;
		
		exitResponse = new Response("(Exit)", this);
		exitResponse.setIsExit(true);
		addResponse(exitResponse);
	}
	
	public void addResponse(Response p_response)
	{
		if(responses == null)
		{
			responses = new ArrayList();
		}
		responses.Insert(0, p_response);
	}
	
	public string getStatement()
	{
		return statement;	
	}
	
	public ArrayList getResponses()
	{
		return responses;
	}
	
	public Response getExitResponse()
	{
		return exitResponse;	
	}
}
