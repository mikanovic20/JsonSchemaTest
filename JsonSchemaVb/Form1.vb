Imports System.IO
Imports System.Text

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Schema
Imports Newtonsoft.Json.Schema.Generation

Public Class Form1

#Region "Fields"

    Private ReadOnly STUDENTS_SCHEMA_FILE As String = "students_schema.json"
    Private ReadOnly STUDENTS_FILE As String = "students.json"

    ''' <summary>
    ''' Json Schema
    ''' </summary>
    Private _studentsSchema As JSchema

#End Region

#Region "Constructors"

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(800, 250)

    End Sub

#End Region

#Region "EventHandlers"

    ''' <summary>
    ''' Create schema And save file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnGenerateJsonSchema_Click(sender As Object, e As EventArgs) Handles btnGenerateJsonSchema.Click

        ' Generate Json Schema of Students(= List(Of Student))
        Dim generator As JSchemaGenerator = New JSchemaGenerator()
        generator.GenerationProviders.Add(New StringEnumGenerationProvider())
        _studentsSchema = generator.Generate(GetType(List(Of Student)))

        Dim filePath As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), STUDENTS_SCHEMA_FILE)

        ' Save File to Schema
        Using sWriter As New StreamWriter(filePath, False, Encoding.UTF8)

            ' @ If use JSchema.WriteTo,
            ' @ schema file Is without indentation.
            ' @ So used JSchema.ToString And wrote to file.
            ' using ( var writer = New JsonTextWriter( streamWriter ) ) {
            '    _studentsSchema.WriteTo( writer );
            '}

            sWriter.Write(_studentsSchema.ToString())

        End Using

        ' Update Display

        richTextBox1.Clear()
        richTextBox1.Text = "Created and Saved Schema."

    End Sub

    ''' <summary>
    ''' Read contents from JSON
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReadJsonContents_Click(sender As Object, e As EventArgs) Handles btnReadJsonContents.Click

        If _studentsSchema Is Nothing Then Return

        Dim students As IList(Of Student) = New List(Of Student)()
        Dim errors As IList(Of String) = New List(Of String)()

        Try
            Dim filePath As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), STUDENTS_FILE)

            ' Load Contents from Json Contents of Students
            Using sReader As New StreamReader(filePath, Encoding.UTF8)
                Using reader As New JsonTextReader(sReader)
                    Using validatingReader As New JSchemaValidatingReader(reader)

                        ' Adapt Schema of Students
                        validatingReader.Schema = _studentsSchema

                        ' Regist Validation Error Event
                        AddHandler validatingReader.ValidationEventHandler,
                            Sub(s, ex)
                                ' Because use default value,
                                ' no check enum of 'BloodType'
                                If ex.ValidationError.ErrorType = ErrorType.Enum AndAlso
                                   ex.ValidationError.Path.Contains("BloodType") Then
                                    Return
                                End If
                                errors.Add(ex.Message)
                            End Sub

                        ' Json Derialize
                        Dim serializer As JsonSerializer = New JsonSerializer()
                        students = serializer.Deserialize(Of List(Of Student))(validatingReader)

                    End Using
                End Using
            End Using

        Catch ex As FileNotFoundException
            errors.Add(ex.Message)
        Catch ex As JsonReaderException
            errors.Add(ex.Message)
        Catch ex As JsonSerializationException
            errors.Add(ex.Message)
        Catch ex As JSchemaValidationException

            ' @ When regist custom eventhandler to JSchemaValidatingReader.ValidationEventHandler,
            ' @ maybe JSchemaValidationException doesn't occur. 
            errors.Add(ex.Message)

        End Try

        If students.Count < 0 Then Return

        ' Update Display

        Dim buffer As StringBuilder = New StringBuilder()
        If errors.Count = 0 Then
            students.ToList().ForEach(Sub(student) buffer.AppendFormat("{0}{1}", student, Environment.NewLine))
        Else
            errors.ToList().ForEach(Sub(err) buffer.AppendFormat("[invalid] : {0}{1}", err, Environment.NewLine))
        End If

        richTextBox1.Clear()
        richTextBox1.Text = buffer.ToString()

    End Sub

#End Region

End Class
