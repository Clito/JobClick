Imports Microsoft.VisualBasic
Imports System.IO


Public Class imagem

    Function ExcluirImagem(ByVal caminho As String) As String

        Dim Resultado As String = ""
        Try
            File.Delete(caminho)
            Resultado = "Foto atualizada!"
        Catch ex As Exception
            Resultado = "Ops..."
        End Try
        File.Delete(caminho)

        Return Resultado

    End Function

    Function NomeArquivoImagem(ByVal pastaorigem As String) As String

        Dim NomeImagem As String = ""

        Dim caminho As String = pastaorigem
        Dim di As New DirectoryInfo(caminho)
        Dim lFiles As FileInfo() = di.GetFiles("*.*")

        For Each fi In lFiles
            NomeImagem = fi.FullName
        Next

        Return NomeImagem

    End Function

    Function NomeArquivoImagemVirtual(ByVal pastaorigem As String, ByVal virtual As String) As String

        Dim NomeImagem As String = ""

        Dim caminho As String = pastaorigem
        Dim di As New DirectoryInfo(caminho)
        Dim lFiles As FileInfo() = di.GetFiles("*.jpeg")

        For Each fi In lFiles
            NomeImagem = virtual & fi.Name
        Next

        Return NomeImagem

    End Function
End Class
