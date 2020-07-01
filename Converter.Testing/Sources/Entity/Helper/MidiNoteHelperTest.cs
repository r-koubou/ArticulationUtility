using NUnit.Framework;

using Spreadsheet2Expressionmap.Converter.Entity.Helper;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entity.Helper
{
    [TestFixture]
    public class MidiNoteHelperTest
    {
        [Test]
        public void NullTest()
        {
        }


        [Test]
        [TestCase( "C-1 (12)" )]
        [TestCase( "C1 (36)" )]
        [TestCase( "C-1" )]
        [TestCase( "C1" )]
        public void CreateTest( string noteName )
        {
            MidiNoteHelper.FromNoteName( noteName );
        }

    }
}