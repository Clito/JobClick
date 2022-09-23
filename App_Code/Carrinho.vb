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
Imports System.Collections.Generic

''' <summary>
''' Summary description for Carrinho
''' </summary>
Public Class Carrinho

    Private Property ListaDeItens() As Dictionary(Of Integer, Integer)
        Get
            Return m_ListaDeItens
        End Get
        Set(value As Dictionary(Of Integer, Integer))
            m_ListaDeItens = Value
        End Set
    End Property
    Private m_ListaDeItens As Dictionary(Of Integer, Integer)

    Public Shared ReadOnly Property Instancia() As Carrinho
        Get
            If HttpContext.Current.Session("carrinho") Is Nothing Then
                HttpContext.Current.Session("carrinho") = New Carrinho()
            End If
            Return DirectCast(HttpContext.Current.Session("carrinho"), Carrinho)
        End Get
    End Property

    Private Sub New()
        Me.ListaDeItens = New Dictionary(Of Integer, Integer)()
    End Sub

    Public Sub Adicionar(id As Integer, quantidade As Integer)
        If Me.ListaDeItens.ContainsKey(id) Then
            Me.ListaDeItens(id) += quantidade
        Else
            Me.ListaDeItens.Add(id, quantidade)
        End If
    End Sub

    Public ReadOnly Property QuantidadeTotal() As Integer
        Get
            Dim total As Integer = 0
            For Each id As Integer In Me.ListaDeItens.Keys
                total += Me.ListaDeItens(id)
            Next
            Return total
        End Get
    End Property

    Public ReadOnly Property TemItens() As Boolean
        Get
            Return Me.ListaDeItens.Count > 0
        End Get
    End Property

    Public ReadOnly Property CodigosDosItens() As Integer()
        Get
            Return Me.ListaDeItens.Keys.ToArray()
        End Get
    End Property

    Public Function ObterQuantidadeDoItem(id As Integer) As Integer
        Return Me.ListaDeItens(id)
    End Function

    Public Sub Limpar()
        Me.ListaDeItens.Clear()
    End Sub
End Class

