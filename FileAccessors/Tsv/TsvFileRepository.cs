using System;
using System.IO;
using System.Text;

using ArticulationUtility.Entities.Tsv.Aggregate;

namespace ArticulationUtility.FileAccessors.Tsv
{
    public class TsvFileRepository : ITsvFileRepository
    {
        public string Suffix { get; } = ".tsv";
        public string LoadPath { get; set; } = string.Empty;
        public string SavePath { get; set; } = string.Empty;

        #region Load
        public TsvData Load()
        {
            throw new NotImplementedException( $"{nameof( Load )}() : Not supported" );
        }
        #endregion Load

        #region Save
        public void Save( TsvData data )
        {
            var fileName = SavePath + Suffix;
            using var stream = File.Open( fileName, FileMode.Create, FileAccess.Write );
            using var writer = new StreamWriter( stream, Encoding.UTF8 );

            foreach( var line in data.Rows )
            {
                writer.WriteLine( line.Line.TrimEnd( '\t' ) );
            }
        }
        #endregion
    }
}