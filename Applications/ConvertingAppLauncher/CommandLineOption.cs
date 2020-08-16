using System;
using System.Collections.Generic;
using System.IO;

using CommandLine;

namespace ConvertingAppLauncher
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "Filename for converting";
        private const string HelpOutputDirectory = "Output directory";

        [Option( 'o', "outputdir", Default = ".", HelpText = HelpOutputDirectory )]
        public string OutputDirectory { get; set; } = string.Empty;

        [Value( 0, Required = true, HelpText = HelpInputFileName)]
        public IEnumerable<string> InputFiles { get; set; } = new List<string>();

        /// <summary>
        /// Supporting extract wildcard for multiplatform.
        /// Windows shell (cmd.exe) cannot expand filename with wildcard.
        /// </summary>
        public IEnumerable<string> InputFilesByWildCard
        {
            get
            {
                var result = new List<string>();

                foreach( var file in InputFiles )
                {
                    result.AddRange( ExtractFileNamesByWildCard( file ) );
                }

                return result;
            }
        }

        /// <summary>
        /// Supporting extract wildcard for multiplatform.
        /// Windows shell (cmd.exe) cannot expand filename with wildcard.
        /// </summary>
        private static IEnumerable<string> ExtractFileNamesByWildCard( string path )
        {
            var result = new List<string>();

            if( path.IndexOf( "*", StringComparison.Ordinal ) == -1 )
            {
                result.Add( path );
                return  result;
            }

            var fullPath = Path.GetFullPath( path );
            var directory = Path.GetDirectoryName( fullPath );
            var fileName = Path.GetFileName( fullPath );
            var files = Directory.GetFiles( directory, fileName, SearchOption.TopDirectoryOnly );

            result.AddRange( files );

            return result;
        }
    }
}