using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JsonSchemaCSharp {

    using Newtonsoft.Json;
    using Newtonsoft.Json.Schema;
    using Newtonsoft.Json.Schema.Generation;

    public partial class Form1 : Form {

        #region Fields

        private static readonly string STUDENTS_SCHEMA_FILE = @"students_schema.json";
        private static readonly string STUDENTS_FILE = @"students.json";

        /// <summary>
        /// Json Schema
        /// </summary>
        private JSchema _studentsSchema;

        #endregion

        #region Constructors

        public Form1() {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size( 800, 250 );
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Create schema and save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateJsonSchema_Click( object sender, EventArgs e ) {

            // Generate Json Schema of Students(= List<StudentSchema>)
            var generator = new JSchemaGenerator();
            generator.GenerationProviders.Add( new StringEnumGenerationProvider() );
            _studentsSchema = generator.Generate( typeof( List<Student> ) );

            var path = Path.Combine( Path.GetDirectoryName( Application.ExecutablePath ), STUDENTS_SCHEMA_FILE );
            
            // Save File to Schema
            using ( var streamWriter = new StreamWriter( path, false, Encoding.UTF8 ) ) {

                // @ If use JSchema.WriteTo,
                // @ schema file is without indentation.
                // @ So used JSchema.ToString and wrote to file.
                //using ( var writer = new JsonTextWriter( streamWriter ) ) {
                //    _studentsSchema.WriteTo( writer );
                //}

                streamWriter.Write( _studentsSchema.ToString() );
            }

            // Update Display

            richTextBox1.Clear();
            richTextBox1.Text = @"Created and Saved Schema.";
        }

        /// <summary>
        /// Read contents from JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadJsonContents_Click( object sender, EventArgs e ) {

            if ( _studentsSchema == null ) return;

            IList<Student> students = new List<Student>();
            IList<string> errors = new List<string>();

            try {

                var path = Path.Combine( Path.GetDirectoryName( Application.ExecutablePath ), STUDENTS_FILE );

                // Load Contents from Json Contents of Students
                using ( var streamReader = new StreamReader( path, Encoding.UTF8 ) )
                using ( var reader = new JsonTextReader( streamReader ) )
                using ( var validatingReader = new JSchemaValidatingReader( reader ) ) {

                    // Adapt Schema of Students
                    validatingReader.Schema = _studentsSchema;

                    // Regist Validation Error Event
                    validatingReader.ValidationEventHandler += ( s, ex ) => {

                        // Because use default value,
                        // no check enum of 'BloodType'
                        if ( ex.ValidationError.ErrorType == ErrorType.Enum &&
                             ex.ValidationError.Path.Contains("BloodType") ) {
                            return;
                        }
                        errors.Add( ex.Message );
                    };

                    // Json Derialize
                    var serializer = new JsonSerializer();
                    students = serializer.Deserialize<List<Student>>( validatingReader );
                }

            } catch ( FileNotFoundException ex ) {
                errors.Add( ex.Message );
            } catch ( JsonReaderException ex ) {
                errors.Add( ex.Message );
            } catch ( JsonSerializationException ex ) {
                errors.Add( ex.Message );
            } catch ( JSchemaValidationException ex ) {

                // @ When regist custom eventhandler to JSchemaValidatingReader.ValidationEventHandler,
                // @ maybe JSchemaValidationException doesn't occur. 
                errors.Add( ex.Message );
            }

            if ( students.Count < 0 ) return;            

            // Update Display

            var buffer = new StringBuilder();
            if ( errors.Count == 0 ) {
                students.ToList().ForEach( student => buffer.AppendFormat( "{0}{1}", student, Environment.NewLine ) );
            } else {
                errors.ToList().ForEach( error => buffer.AppendFormat( "[invalid] : {0}{1}", error, Environment.NewLine ) );
            }

            richTextBox1.Clear();
            richTextBox1.Text = buffer.ToString();
        }

        #endregion
    }
}
