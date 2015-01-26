Imports System
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.TextFieldParser

Public Class Form1

    Private Sub btParser_Click(sender As Object, e As EventArgs) Handles btParser.Click

        '-------FARMACI CLASSE A ------------
        Dim InputFile As String = My.Application.Info.DirectoryPath & "\TXT\Classe_A_Nome_Commerciale_17-11-2014.csv"
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(InputFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(";")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()

                    Dim PrincipioAttivo As String = currentRow(0)
                    Dim Descrizione As String = currentRow(1)
                    Dim strArr() As String
                    Dim str = currentRow(2)
                    strArr = str.Split("*")
                    Dim Denominazione As String = strArr(0)
                    Dim Confezione As String = strArr(1)
                    Dim Prezzo As String = currentRow(3)
                    Dim Ditta As String = currentRow(4)
                    Dim AIC As String = currentRow(5)

                    Dim Classe As String = "A"

                    'DGV.Rows.Add(New String() {PrincipioAttivo.ToUpper, Descrizione, Denominazione, Confezione, Prezzo, Ditta, AIC, Classe})
                    Me.TblFarmaciTableAdapter.InsertQuery(PrincipioAttivo.ToUpper, Descrizione, Denominazione, Confezione, Prezzo, Ditta.ToUpper, AIC, Classe)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    Stop
                End Try
            End While
        End Using

        '-------FARMACI CLASSE H ------------
        InputFile = My.Application.Info.DirectoryPath & "\TXT\Classe_H_Nome_Commerciale_17-11-2014.csv"
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(InputFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(";")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()

                    Dim PrincipioAttivo As String = currentRow(0)
                    Dim Descrizione As String = currentRow(1)
                    Dim strArr() As String
                    Dim str = currentRow(2)
                    strArr = str.Split("*")
                    Dim Denominazione As String = strArr(0)
                    Dim Confezione As String = strArr(1)
                    Dim Prezzo As String = currentRow(3)
                    Dim Ditta As String = currentRow(6)
                    Dim AIC As String = currentRow(7)
                    Dim Classe As String = "H"

                    'DGV.Rows.Add(New String() {PrincipioAttivo.ToUpper, Descrizione, Denominazione, Confezione, Prezzo, Ditta, AIC, Classe})
                    Me.TblFarmaciTableAdapter.InsertQuery(PrincipioAttivo.ToUpper, Descrizione, Denominazione, Confezione, Prezzo, Ditta.ToUpper, AIC, Classe)

                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    Stop
                End Try
            End While
        End Using

        '-------FARMACI CLASSE C ------------
        InputFile = My.Application.Info.DirectoryPath & "\TXT\lista_trasp_fascia_c_071108.csv"
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(InputFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(";")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()

                    Dim PrincipioAttivo As String = currentRow(0)
                    Dim Descrizione As String = ""
                    Dim Denominazione As String = currentRow(2)
                    Dim Confezione As String = currentRow(3)
                    Dim Prezzo As String = currentRow(5)
                    Dim Ditta As String = currentRow(4)
                    Dim AIC As String = currentRow(1)
                    Dim Classe As String = "C"

                    'DGV.Rows.Add(New String() {PrincipioAttivo.ToUpper, Descrizione, Denominazione, Confezione, Prezzo, Ditta.ToUpper, AIC, Classe})
                    Me.TblFarmaciTableAdapter.InsertQuery(PrincipioAttivo.ToUpper, Descrizione, Denominazione, Confezione, Prezzo, Ditta.ToUpper, AIC, Classe)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    Stop
                End Try
            End While
        End Using
        'Me.TableAdapterManager.UpdateAll(Me.ElencoFarmaciDataSet)
        Me.TblFarmaciTableAdapter.Fill(Me.ElencoFarmaciDataSet.tblFarmaci)
    End Sub

    Private Sub TblFarmaciBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TblFarmaciBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ElencoFarmaciDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: questa riga di codice carica i dati nella tabella 'ElencoFarmaciDataSet.tblFarmaci'. È possibile spostarla o rimuoverla se necessario.
        Me.TblFarmaciTableAdapter.Fill(Me.ElencoFarmaciDataSet.tblFarmaci)

    End Sub
End Class
