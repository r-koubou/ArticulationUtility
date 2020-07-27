namespace ArticulationUtility.UseCases.Values.VSTExpressionMapXml.XmlClasses
{
    public static class PSlotNoteChanger
    {
        public static ObjectElement New()
        {
#if false
            <obj class="PSlotNoteChanger" ID="1015887872">
               <int name="channel" value="-1"/>
               <float name="velocityFact" value="0.25"/>
               <float name="lengthFact" value="0.5"/>
               <int name="minVelocity" value="0"/>
               <int name="maxVelocity" value="127"/>
               <int name="transpose" value="48"/>
               <int name="minPitch" value="0"/>
               <int name="maxPitch" value="127"/>
            </obj>
#endif
            var obj = new ObjectElement( "PSlotNoteChanger" );

            obj.Int.Add( new IntElement( "channel", -1 ) );
            obj.Float.Add( new FloatElement( "velocityFact", 1f ) );
            obj.Float.Add( new FloatElement( "lengthFact",   1f ) );
            obj.Int.Add( new IntElement( "minVelocity", 0 ) );
            obj.Int.Add( new IntElement( "maxVelocity", 127 ) );
            obj.Int.Add( new IntElement( "transpose",   0 ) );
            obj.Int.Add( new IntElement( "minPitch",    0 ) );
            obj.Int.Add( new IntElement( "maxPitch",    127 ) );

            return obj;
        }
    }
}