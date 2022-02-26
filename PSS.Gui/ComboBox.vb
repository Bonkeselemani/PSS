Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Controls
    '<ToolboxBitmapAttribute(GetType(System.Windows.Forms.ComboBox))> _
    <ToolboxBitmap(GetType(System.Windows.Forms.ComboBox))> _
    Public Class ComboBox
        Inherits System.Windows.Forms.ComboBox

        Private _autoComplete As Boolean = False

        Public Sub New()
        End Sub

        Public Sub AddItem(ByVal ID As Integer, ByVal Text As String)
            Dim comboBoxItem As comboBoxItem = New comboBoxItem(ID, Text)
            MyBase.Items.Add(comboBoxItem)
        End Sub
        Public Sub AddItem(ByVal comboBoxItem As ComboBoxItem)
            MyBase.Items.Add(comboBoxItem)
        End Sub

        Public Function GetID() As Int32
            Try
                Return (CType(MyBase.Items(MyBase.SelectedIndex), ComboBoxItem)).ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetID(ByVal Index As Int32) As Int32
            Try
                Return (CType(MyBase.Items(Index), ComboBoxItem)).ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        <Category("Behavior"), DefaultValue(False)> _
        Public Property AutoComplete() As Boolean
            Get
                Return _autoComplete
            End Get
            Set(ByVal Value As Boolean)
                _autoComplete = Value
            End Set
        End Property

        Private Sub SetAutoComplete(ByVal sender As Object, ByVal Param As KeyPressEventArgs) Handles MyBase.KeyPress
            If _autoComplete = True Then
                Dim CB As Integer
                Dim FindString As String
                If Asc(Param.KeyChar) = Keys.Escape Then
                    MyBase.SelectedIndex = -1
                    MyBase.Text = ""
                ElseIf Asc(Param.KeyChar) = Keys.Back Then
                    'do normal functionallity so we can backspace.
                Else
                    FindString = MyBase.Text
                    CB = MyBase.FindString(FindString)
                    If CB <> -1 Then
                        MyBase.SelectedIndex = CB
                        MyBase.SelectionStart = FindString.Length
                        MyBase.SelectionLength = MyBase.Text.Length - MyBase.SelectionStart
                    End If
                End If
                Param.Handled = True
            End If
        End Sub


    End Class

    Public Class ComboBoxItem
        Private mID As Integer
        Private mText As String

        Public Sub New(ByVal ID As Integer, ByVal Text As String)
            mID = ID
            mText = Trim(Text)
        End Sub
        Public ReadOnly Property ID() As Integer
            Get
                Return mID
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return Trim(mText)
        End Function
    End Class

End Namespace