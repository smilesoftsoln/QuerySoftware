'Imports Microsoft.VisualBasic
'Imports System.Data.SqlClient
'Imports System.Data
'Namespace projecterNM
'    Public Class DBField
'        Public fieldName As String
'        Public value As String
'        Public dataType As Integer  '1=String, 2=Number
'    End Class
'    Public Class projectercon

'        Public con As New SqlConnection
'        Public ds As DataSet
'        Public adp As SqlDataAdapter
'        Public ReadOnly Property ConObj() As Object
'            Get
'                If con.State = Data.ConnectionState.Open Then con.Close()
'                con.ConnectionString = "Data Source=sri;Initial Catalog=tn_CAREE_bita;Integrated Security=True"
'                'con.ConnectionString = "Data Source=SRI;Initial Catalog=db_trade_master;Integrated Security=True"
'                con.Open()
'                ConObj = con
'            End Get
'        End Property
'        Public Function InsertRecordIntoTable(ByVal tableName As String, ByVal values As Queue, ByVal fieldsSpecified As Boolean) As Boolean
'            Dim current As DBField
'            Dim inStr As String = "insert into " + tableName + " "
'            Dim fieldsStr As String = "("
'            Dim valuesStr As String = " values ("
'            While (values.Count > 0)
'                current = values.Dequeue()
'                If fieldsSpecified = True Then
'                    fieldsStr = fieldsStr + current.fieldName + ","
'                End If

'                If current.dataType = 1 Then 'String
'                    valuesStr = valuesStr + "'" + current.value + "',"
'                Else                         'Number
'                    valuesStr = valuesStr + current.value + ","
'                End If
'            End While
'            'Remove Commas
'            If fieldsSpecified = True Then
'                fieldsStr = fieldsStr.Remove(fieldsStr.Length - 1) + ")"
'            Else
'                fieldsStr = " "
'            End If
'            valuesStr = valuesStr.Remove(valuesStr.Length - 1) + ")"
'            inStr = inStr + fieldsStr + valuesStr
'            Return InsertRecord(inStr)
'        End Function

'        Public Function InsertRecord(ByVal insStr As String) As Boolean
'            'con.Open()
'            Dim cmd As SqlCommand = New SqlCommand(insStr, ConObj)
'            Dim retval As Integer = cmd.ExecuteNonQuery
'            Return retval
'        End Function

'        Public Function SelectQuery(ByVal insStr As String) As SqlDataReader
'            'con.Open()
'            Dim cmd As SqlCommand = New SqlCommand(insStr, ConObj)
'            Dim retval As SqlDataReader = cmd.ExecuteReader
'            Return retval
'        End Function

'    End Class
'End Namespace