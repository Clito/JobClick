
Imports System.Data
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports UOL.PagSeguro

''' <summary>
''' Summary description for AcessoDados
''' </summary>
Public Class AcessoDados

    Private Shared _instancia As AcessoDados
    Public Shared ReadOnly Property Instancia() As AcessoDados
        Get
            If _instancia Is Nothing Then
                _instancia = New AcessoDados()
            End If
            Return _instancia
        End Get
    End Property


    Private Sub New()
    End Sub

    REM ** **********************************************************************
    REM ** Adicionar o pedido na sua base de dados
    REM ** **********************************************************************

    Public Function GravarPedido(carrinho As Carrinho) As String
        Return Convert.ToString(New Random().[Next]())
    End Function

    REM ** **********************************************************************
    REM ** Aqui você deve atualizar o pedido na sua base de dados
    REM ** **********************************************************************

    Public Sub AtualizarVenda(pedido As Integer, transacao As String, status As StatusTransacao, forma_pagamento As String, frete As Double, anotacao As String)

    End Sub
End Class

