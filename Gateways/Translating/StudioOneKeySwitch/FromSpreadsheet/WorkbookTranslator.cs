using System.Collections.Generic;
using System.Linq;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.Gateways.Translating.MidiEvent.FromSpreadsheet;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Aggregate;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromSpreadsheet
{
    public class WorkbookTranslator : IDataTranslator<Workbook, List<KeySwitch>>
    {
        public List<KeySwitch> Translate( Workbook workbook )
        {
            var result = new List<KeySwitch>();

            foreach( var worksheet in workbook.Worksheets )
            {
                var name = new KeySwitchListName( worksheet.OutputNameCell.Value );
                var keySwitch = new KeySwitch( name );

                ConvertRows( worksheet.Rows, keySwitch );

                result.Add( keySwitch );
            }
            return result;
        }

        private void ConvertRows( IEnumerable<Row> rows, KeySwitch keySwitch )
        {
            foreach( var row in rows )
            {
                var name = new KeySwitchName( row.ArticulationName.Value );

                // To Midi note
                if( ConvertMidiNoteMapping( row, out var midi ) )
                {
                    var element = new KeySwitchElement(
                        name,
                        new KeySwitchPitch( midi.DataByte1.Value )
                    );
                    keySwitch.KeySwitchList.Add( element );
                }
            }
        }

        private bool ConvertMidiNoteMapping( Row row, out MidiNoteOn result )
        {
            result = default!;

            var noteNumberAdapter = new MidiNoteNumberCellToMidiNoteNumber();
            var noteVelocityAdapter = new MidiNoteVelocityCellToVelocity();

            if( row.MidiNoteList.Count == 0 )
            {
                return false;
            }

            // if multiple note on defined, select a first midi note.
            var midiNote = row.MidiNoteList.First();

            result = new MidiNoteOn(
                noteNumberAdapter.Translate( midiNote.Note ),
                noteVelocityAdapter.Translate( midiNote.Velocity )
            );

            return true;
        }
    }
}