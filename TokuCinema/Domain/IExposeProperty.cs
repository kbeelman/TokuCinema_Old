namespace TokuCinema.Domain
{	
	public interface IExposeProperty
	{
		string ExposePropertyValue(string propertyName);
		/*
		Concept
		{
			// implement the action of returning a value from a class level property		
			string value = this.GetType().GetProperty(prompertyName).GetValue(this, null);
			return value;
		}
		*/
	}	
}