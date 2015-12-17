Imports System
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class DGMC_Customers
    Inherits DataGridViewColumn
    Private _Datatabel As DataTable
    Private _ViewColumn As Integer

    Public Sub New()
        MyBase.New(New DGMC_CustomersMulticolumncomboCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(DGMC_CustomersMulticolumncomboCell)) _
                Then
                Throw New InvalidCastException("Must be DGMC_CustomersMulticolumncomboCell!")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class DGMC_CustomersMulticolumncomboCell
    Inherits DataGridViewTextBoxCell
    Private _DefaultHeaderCellType As System.Type
    Private _Sortmode As DataGridViewColumnSortMode
    Private _Headercell As DataGridViewHeaderCell

    Public Sub New()

    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        Try
            If Not rowIndex = -1 Then
                MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                    dataGridViewCellStyle)
                Dim ctl As DGMC_CustomersMultiColumnComboEditingControl = _
                    CType(DataGridView.EditingControl, DGMC_CustomersMultiColumnComboEditingControl)
                ctl.Text = Me.Value.ToString
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Property Headercell() As DataGridViewHeaderCell
        Get
            Return _Headercell
        End Get
        Set(ByVal value As DataGridViewHeaderCell)
            _Headercell = value
        End Set
    End Property
    Public Property Sortmode() As DataGridViewColumnSortMode
        Get
            Return _Sortmode
        End Get
        Set(ByVal value As DataGridViewColumnSortMode)
            _Sortmode = value
        End Set
    End Property
    Public Property DefaultHeaderCellType() As System.Type
        Get
            Return _DefaultHeaderCellType
        End Get
        Set(ByVal value As System.Type)
            _DefaultHeaderCellType = value
        End Set
    End Property
    
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(DGMC_CustomersMultiColumnComboEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(String)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return String.Empty
        End Get
    End Property

End Class

Public Class DGMC_CustomersMultiColumnComboEditingControl
    Inherits ComboboxMultipleColumn
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Data_Table = Nothing
        Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.FlatComboStyle = ComboboxMultipleColumn.styles.office2003
        Me.FormattingEnabled = True
        Me.Column_Widths = Nothing
        Me.Column_Values = Nothing
        Me.MaxDropDownItems = 25
        Dim cn As New Data.SqlClient.SqlConnection("Server=.\SQLExpress;AttachDbFilename=" & Application.StartupPath & "northwnd.mdf;Database=Northwind;Trusted_Connection=Yes;")
        cn.Open()
        Try
            Dim s_SQL As String = "SELECT TOP 100 PERCENT CustomerID, CompanyName  " _
                & "FROM Customers ORDER BY CustomerID"
            Dim cmd As New Data.SqlClient.SqlCommand(s_SQL, cn)
            Dim daa As New Data.SqlClient.SqlDataAdapter
            daa.SelectCommand = cmd
            Dim dss As New Data.DataSet
            daa.Fill(dss)
            Me.Load_Data(dss.Tables(0), "CustomerID", "CustomerID")
            Me.Column_Widthsetting("100;300")
            Me.Text = ""
        Catch ex As Exception

        End Try
        cn.Close()
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Text
        End Get

        Set(ByVal value As Object)
            '  If TypeOf value Is String Then
            Me.Text = value
            '  End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Try
            Return Me.Text
        Catch ex As Exception
            Return String.Empty
        End Try


    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Try
            Me.Font = dataGridViewCellStyle.Font
        Catch ex As Exception

        End Try

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return False

            Case Else
                Return True
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub Onselectedindexchanged(ByVal eventargs As EventArgs)
        Try
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnSelectedIndexChanged(eventargs)
        Catch ex As Exception

        End Try
    End Sub
End Class
