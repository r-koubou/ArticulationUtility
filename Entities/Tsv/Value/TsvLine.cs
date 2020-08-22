using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.Tsv.Value
{
    public class TsvLine
    {
        public const char SeparatorChar = '\t';
        public const string Separator = "\t";

        public string Line { get; }

        public TsvLine( string line )
        {
            if( StringHelper.IsNullOrTrimEmpty( line ) )
            {
                throw new InvalidNameException( nameof( line ) );
            }
            Line = line;
        }
    }
}