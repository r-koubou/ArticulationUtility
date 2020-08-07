using System;

namespace ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromVSTExpressionMapXml
{
    public class ElementNotFoundException : Exception
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