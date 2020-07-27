namespace ArticulationUtility.Adapters.VSTExpressionMap.FromVSTExpressionMapXml
{
    public class ElementNotFoundException : System.Exception
    {
        public ElementNotFoundException( string elementName ) :
            base( $"Element {elementName} : not found")
        {
        }

        public ElementNotFoundException() :
            base( "Element not found" )
        {
        }
    }
}