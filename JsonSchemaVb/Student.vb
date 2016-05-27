Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters

Public Class Student

#Region "Properties"

    <Required>
    <RegularExpression("^[A-Z][0-9]{7}?$")>
    <JsonProperty(Order:=1, Required:=Required.Always)>
    Public Property Id As String

    <Required>
    <StringLength(20)>
    <JsonProperty(Order:=2, Required:=Required.Always)>
    Public Property Name As String

    <Required>
    <DataType(DataType.DateTime)>
    <JsonProperty(Order:=3)>
    Public Property Birth As DateTime

    <Required>
    <EnumDataType(GetType(BloodType))>
    <JsonProperty(Order:=4)>
    <JsonConverter(GetType(BloodTypeEnumConverter))>
    Public Property BloodType As BloodType

#End Region

#Region "Constructors"

    Public Sub New()
    End Sub

#End Region

#Region "Public Methods - Overrides"

    Public Overrides Function ToString() As String

        Return String.Format("ID        : {0}{4}" +
                             "Name      : {1}{4}" +
                             "Birth     : {2:yyyy/MM/dd}{4}" +
                             "BloodType : {3}{4}",
                             Id, Name, Birth, BloodType.ToString(), Environment.NewLine)
    End Function

#End Region

End Class

Public Enum BloodType
    Undefined
    A
    B
    O
    AB
End Enum

Public Class BloodTypeEnumConverter
    Inherits StringEnumConverter

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object

        Try
            Return MyBase.ReadJson(reader, objectType, existingValue, serializer)
        Catch ex As Exception
            Return BloodType.Undefined
        End Try

    End Function

End Class

