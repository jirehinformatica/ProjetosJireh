Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient

Public Class SQLDatagridview
    Inherits DataGridView

    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_KEYUP As Integer = &H101
    Private Const WM_CHAR As Integer = &H102
    Private _iColumn_Clicked As Integer = 0
    Private _Combobox_Columns As String
    Private _Defaultvalue_Columns As String
    Private _Default_Values As String
    Private _Background_Color As Color = Color.White
    Private _Header_Height As Integer = 23
    Private _Column_Reorder As Boolean = True
    Private _Edit_Mode As DataGridViewEditMode = DataGridViewEditMode.EditOnEnter
    Private _Multiple_Rowselection As Boolean = False
    Private _Rowheader_Visible As Boolean = False
    Private _Binding_Source As BindingSource

    Private _Connection_String As String = ""
    Private _Table_Name As String = ""
    Private cn As SqlConnection
    Private s_SQL As String = ""
    Private sSQL As String = ""
    Private sqlKeys As String = ""
    Private cmd As SqlCommand
    Private _e As System.Data.DataRowChangeEventArgs
    Private _Header_Selected As Integer = -1
    Private drRegion As Rectangle
    Friend WithEvents conMenu As ContextMenuStrip
    Friend WithEvents SearchTextbox1 As SearchTextbox
    Friend WithEvents contoolYes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contoolNo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolFilternull As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contoolYesNo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContoolValue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContoolDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchValueGreater As SearchTextbox
    Friend WithEvents SearchValueSmaller As SearchTextbox
    Friend WithEvents SearchValueEqual As SearchTextbox
    Friend WithEvents SearchDateGreater As SearchTextbox
    Friend WithEvents SearchDateSmaller As SearchTextbox
    Friend WithEvents SearchDateEqual As SearchTextbox
    Friend WithEvents ToolFilternotnull As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortAsc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortDesc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents conTooltext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolFilterNone As System.Windows.Forms.ToolStripMenuItem

    Private _Sort_Array() As Integer = Nothing
    Private _Filter_Array() As Integer = Nothing

    Public Property Filter_Array() As Integer()
        Get
            Return _Filter_Array
        End Get
        Set(ByVal value As Integer())
            _Filter_Array = value
        End Set
    End Property

    Public Property Sort_Array() As Integer()
        Get
            Return _Sort_Array
        End Get
        Set(ByVal value As Integer())
            _Sort_Array = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.BackgroundColor = Background_Color
        Me.ColumnHeadersHeight = Header_Height
        Me.AllowUserToOrderColumns = Column_Reorder
        Me.EditMode = Edit_Mode
        Me.MultiSelect = Multiple_Rowselection
        Me.RowHeadersVisible = Rowheader_Visible
        conMenu = New ContextMenuStrip
        conMenu.AutoSize = True
        SortAsc = New ToolStripMenuItem
        SortAsc.AutoSize = True
        SortAsc.Text = "Ordem : Crescente"
        conMenu.Items.Add(SortAsc)
        SortDesc = New ToolStripMenuItem
        SortDesc.AutoSize = True
        SortDesc.Text = "Ordem : Decrescente"
        conMenu.Items.Add(SortDesc)
        'SortNone = New ToolStripMenuItem
        'SortNone.AutoSize = True
        'SortNone.Text = "Sort : NONE"
        'conMenu.Items.Add(SortNone)
        conTooltext = New ToolStripMenuItem
        conTooltext.AutoSize = True
        conTooltext.Text = "Filtro"
        SearchTextbox1 = New SearchTextbox
        SearchTextbox1.AutoSize = True
        SearchTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchTextbox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        conTooltext.DropDownItems.Add(SearchTextbox1)
        conMenu.Items.Add(conTooltext)
        contoolYesNo = New ToolStripMenuItem
        contoolYesNo.AutoSize = True
        contoolYesNo.Text = "Filter on True/False : "
        contoolYes = New ToolStripMenuItem
        contoolYes.Text = "Yes"
        contoolYesNo.DropDownItems.Add(contoolYes)
        contoolNo = New ToolStripMenuItem
        contoolNo.Text = "No"
        contoolYesNo.DropDownItems.Add(contoolNo)
        conMenu.Items.Add(contoolYesNo)
        ContoolValue = New ToolStripMenuItem
        ContoolValue.AutoSize = True
        ContoolValue.Text = "Filter on value"
        Dim item As New ToolStripMenuItem
        item.Text = ">"
        SearchValueGreater = New SearchTextbox
        SearchValueGreater.AutoSize = True
        SearchValueGreater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchValueGreater.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        item.DropDownItems.Add(SearchValueGreater)
        ContoolValue.DropDownItems.Add(item)
        item = New ToolStripMenuItem
        item.Text = "<"
        SearchValueSmaller = New SearchTextbox
        SearchValueSmaller.AutoSize = True
        SearchValueSmaller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchValueSmaller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        item.DropDownItems.Add(SearchValueSmaller)
        ContoolValue.DropDownItems.Add(item)
        item = New ToolStripMenuItem
        item.Text = "="
        SearchValueEqual = New SearchTextbox
        SearchValueEqual.AutoSize = True
        SearchValueEqual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchValueEqual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        item.DropDownItems.Add(SearchValueEqual)
        ContoolValue.DropDownItems.Add(item)
        conMenu.Items.Add(ContoolValue)

        ContoolDate = New ToolStripMenuItem
        ContoolDate.AutoSize = True
        ContoolDate.Text = "Filter on date"
        item = New ToolStripMenuItem
        item.Text = ">"
        SearchDateGreater = New SearchTextbox
        SearchDateGreater.AutoSize = True
        SearchDateGreater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchDateGreater.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        item.DropDownItems.Add(SearchDateGreater)
        ContoolDate.DropDownItems.Add(item)
        item = New ToolStripMenuItem
        item.Text = "<"
        SearchDateSmaller = New SearchTextbox
        SearchDateSmaller.AutoSize = True
        SearchDateSmaller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchDateSmaller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        item.DropDownItems.Add(SearchDateSmaller)
        ContoolDate.DropDownItems.Add(item)
        item = New ToolStripMenuItem
        item.Text = "="
        SearchDateEqual = New SearchTextbox
        SearchDateEqual.AutoSize = True
        SearchDateEqual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        SearchDateEqual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        item.DropDownItems.Add(SearchDateEqual)
        ContoolDate.DropDownItems.Add(item)
        conMenu.Items.Add(ContoolDate)

        'ToolFilternull = New ToolStripMenuItem
        'ToolFilternull.AutoSize = True
        'ToolFilternull.Text = "Filter null values"
        'conMenu.Items.Add(ToolFilternull)

        'ToolFilternotnull = New ToolStripMenuItem
        'ToolFilternotnull.AutoSize = True
        'ToolFilternotnull.Text = "Filter non-null values"
        'conMenu.Items.Add(ToolFilternotnull)

        ToolFilterNone = New ToolStripMenuItem
        ToolFilterNone.AutoSize = True
        ToolFilterNone.Text = "Limpar filtros"
        conMenu.Items.Add(ToolFilterNone)
    End Sub

    Public Property Binding_Source() As BindingSource
        Get
            Return _Binding_Source
        End Get
        Set(ByVal value As BindingSource)
            _Binding_Source = value
        End Set
    End Property

    Public Property Header_Selected() As Integer
        Get
            Return _Header_Selected
        End Get
        Set(ByVal value As Integer)
            _Header_Selected = value
        End Set
    End Property

    Public Property Connection_String() As String
        Get
            Return _Connection_String
        End Get
        Set(ByVal value As String)
            _Connection_String = value
        End Set
    End Property

    Public Property e() As System.Data.DataRowChangeEventArgs
        Get
            Return _e
        End Get
        Set(ByVal value As System.Data.DataRowChangeEventArgs)
            _e = value
        End Set
    End Property

    Public Property Table_Name() As String
        Get
            Return _Table_Name
        End Get
        Set(ByVal value As String)
            _Table_Name = value
        End Set
    End Property

    Public Property Rowheader_Visible() As Boolean
        Get
            Return _Rowheader_Visible
        End Get
        Set(ByVal value As Boolean)
            _Rowheader_Visible = value
        End Set
    End Property

    Public Property Multiple_Rowselection() As Boolean
        Get
            Return _Multiple_Rowselection
        End Get
        Set(ByVal value As Boolean)
            _Multiple_Rowselection = value
        End Set
    End Property

    Public Property Edit_Mode() As DataGridViewEditMode
        Get
            Return _Edit_Mode
        End Get
        Set(ByVal value As DataGridViewEditMode)
            _Edit_Mode = value
        End Set
    End Property

    Public Property Column_Reorder() As Boolean
        Get
            Return _Column_Reorder
        End Get
        Set(ByVal value As Boolean)
            _Column_Reorder = value
        End Set
    End Property

    Public Property Header_Height() As Integer
        Get
            Return _Header_Height
        End Get
        Set(ByVal value As Integer)
            _Header_Height = value
        End Set
    End Property

    Public Property Background_Color() As Color
        Get
            Return _Background_Color
        End Get
        Set(ByVal value As Color)
            _Background_Color = value
        End Set
    End Property

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{TAB}")
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Property iColumn_Clicked() As Integer
        Get
            Return _iColumn_Clicked
        End Get
        Set(ByVal value As Integer)
            _iColumn_Clicked = value
        End Set
    End Property

    Protected Overrides Sub OnCellMouseDown(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.Rows(e.RowIndex).Selected = True
                iColumn_Clicked = e.ColumnIndex
            End If
            MyBase.OnCellMouseDown(e)
        Catch ex As Exception

        End Try
    End Sub

    Public Property Combobox_Columns() As String
        Get
            Return _Combobox_Columns
        End Get
        Set(ByVal value As String)
            _Combobox_Columns = value
        End Set
    End Property

    Protected Overrides Sub OnDataError(ByVal displayErrorDialogIfNoHandler As Boolean, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Try
            If Not (Combobox_Columns = "") Then
                Dim sTmp() As String = Combobox_Columns.Split(";")
                If Array.IndexOf(sTmp, Me.Columns(e.ColumnIndex).DataPropertyName) > -1 Then
                    Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Property Defaultvalue_Columns() As String
        Get
            Return _Defaultvalue_Columns
        End Get
        Set(ByVal value As String)
            _Defaultvalue_Columns = value
        End Set
    End Property

    Public Property Default_Values() As String
        Get
            Return _Default_Values
        End Get
        Set(ByVal value As String)
            _Default_Values = value
        End Set
    End Property

    Protected Overrides Sub OnDefaultValuesNeeded(ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        Try

            If Not (Defaultvalue_Columns = "") Then
                Dim sTmp() As String = Defaultvalue_Columns.Split(";")
                Dim sValues() As String = Default_Values.Split(";")

                For i As Integer = 0 To sTmp.GetUpperBound(0)
                    Select Case Me.Columns(sTmp(i)).ValueType.ToString
                        Case "System.String"
                            e.Row.Cells(sTmp(i)).Value = sValues(i)
                        Case "System.Int16"
                            Try
                                e.Row.Cells(sTmp(i)).Value = Integer.Parse(sValues(i))
                            Catch ex As Exception

                            End Try
                        Case "System.Int32"
                            Try
                                e.Row.Cells(sTmp(i)).Value = Integer.Parse(sValues(i))
                            Catch ex As Exception

                            End Try
                        Case "System.DateTime"
                            Try
                                e.Row.Cells(sTmp(i)).Value = DateTime.Parse(sValues(i))
                            Catch ex As Exception

                            End Try
                        Case "System.Double"
                            Try
                                e.Row.Cells(sTmp(i)).Value = Double.Parse(sValues(i))
                            Catch ex As Exception

                            End Try
                        Case "System.Boolean"
                            Try
                                e.Row.Cells(sTmp(i)).Value = Boolean.Parse(sValues(i))
                            Catch ex As Exception

                            End Try
                        Case Else

                    End Select
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared anyRight As ContentAlignment = (ContentAlignment.BottomRight _
                Or (ContentAlignment.MiddleRight Or ContentAlignment.TopRight))

    Public Shared anyTop As ContentAlignment = (ContentAlignment.TopRight _
                Or (ContentAlignment.TopCenter Or ContentAlignment.TopLeft))

    Public Shared anyBottom As ContentAlignment = (ContentAlignment.BottomRight _
                Or (ContentAlignment.BottomCenter Or ContentAlignment.BottomLeft))

    Public Shared anyCenter As ContentAlignment = (ContentAlignment.BottomCenter _
                Or (ContentAlignment.MiddleCenter Or ContentAlignment.TopCenter))

    Public Shared anyMiddle As ContentAlignment = (ContentAlignment.MiddleRight _
                Or (ContentAlignment.MiddleCenter Or ContentAlignment.MiddleLeft))


    Private Sub Draw_Background(ByVal g As Graphics, ByVal obj As Image, ByVal r As Rectangle, ByVal index As Integer)
        If (obj Is Nothing) Then
            Return
        End If
        Dim oWidth As Integer = obj.Width
        Dim lr As Rectangle = Rectangle.FromLTRB(0, 0, 0, 0)
        Dim r2 As Rectangle
        Dim r1 As Rectangle
        Dim x As Integer = ((index - 1) _
                    * oWidth)
        Dim y As Integer = 0
        Dim x1 As Integer = r.Left
        Dim y1 As Integer = r.Top
        If ((r.Height > obj.Height) _
                    AndAlso (r.Width <= oWidth)) Then
            r1 = New Rectangle(x, y, oWidth, lr.Top)
            r2 = New Rectangle(x1, y1, r.Width, lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle(x, (y + lr.Top), oWidth, (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle(x1, (y1 + lr.Top), r.Width, (r.Height _
                            - (lr.Top - lr.Bottom)))
            If ((lr.Top + lr.Bottom) _
                        = 0) Then
                r1.Height = (r1.Height - 1)
            End If
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle(x, (y _
                            + (obj.Height - lr.Bottom)), oWidth, lr.Bottom)
            r2 = New Rectangle(x1, (y1 _
                            + (r.Height - lr.Bottom)), r.Width, lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
        ElseIf ((r.Height <= obj.Height) _
                    AndAlso (r.Width > oWidth)) Then
            r1 = New Rectangle(x, y, lr.Left, obj.Height)
            r2 = New Rectangle(x1, y1, lr.Left, r.Height)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle((x + lr.Left), y, (oWidth _
                            - (lr.Left - lr.Right)), obj.Height)
            r2 = New Rectangle((x1 + lr.Left), y1, (r.Width _
                            - (lr.Left - lr.Right)), r.Height)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), y, lr.Right, obj.Height)
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), y1, lr.Right, r.Height)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
        ElseIf ((r.Height <= obj.Height) _
                    AndAlso (r.Width <= oWidth)) Then
            r1 = New Rectangle(((index - 1) _
                            * oWidth), 0, oWidth, (obj.Height - 1))

            g.DrawImage(obj, New Rectangle(x1, y1, r.Width, r.Height), r1, GraphicsUnit.Pixel)
        ElseIf ((r.Height > obj.Height) _
                    AndAlso (r.Width > oWidth)) Then
            'top-left
            r1 = New Rectangle(x, y, lr.Left, lr.Top)
            r2 = New Rectangle(x1, y1, lr.Left, lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'top-bottom
            r1 = New Rectangle(x, (y _
                            + (obj.Height - lr.Bottom)), lr.Left, lr.Bottom)
            r2 = New Rectangle(x1, (y1 _
                            + (r.Height - lr.Bottom)), lr.Left, lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'left
            r1 = New Rectangle(x, (y + lr.Top), lr.Left, (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle(x1, (y1 + lr.Top), lr.Left, (r.Height _
                            - (lr.Top - lr.Bottom)))
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'top
            r1 = New Rectangle((x + lr.Left), y, (oWidth _
                            - (lr.Left - lr.Right)), lr.Top)
            r2 = New Rectangle((x1 + lr.Left), y1, (r.Width _
                            - (lr.Left - lr.Right)), lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'right-top
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), y, lr.Right, lr.Top)
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), y1, lr.Right, lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'Right
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), (y + lr.Top), lr.Right, (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), (y1 + lr.Top), lr.Right, (r.Height _
                            - (lr.Top - lr.Bottom)))
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'right-bottom
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), (y _
                            + (obj.Height - lr.Bottom)), lr.Right, lr.Bottom)
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), (y1 _
                            + (r.Height - lr.Bottom)), lr.Right, lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'bottom
            r1 = New Rectangle((x + lr.Left), (y _
                            + (obj.Height - lr.Bottom)), (oWidth _
                            - (lr.Left - lr.Right)), lr.Bottom)
            r2 = New Rectangle((x1 + lr.Left), (y1 _
                            + (r.Height - lr.Bottom)), (r.Width _
                            - (lr.Left - lr.Right)), lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'Center
            r1 = New Rectangle((x + lr.Left), (y + lr.Top), (oWidth _
                            - (lr.Left - lr.Right)), (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle((x1 + lr.Left), (y1 + lr.Top), (r.Width _
                            - (lr.Left - lr.Right)), (r.Height _
                            - (lr.Top - lr.Bottom)))
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
        End If
    End Sub

    Private Function HAlignWithin(ByVal alignThis As Size, ByVal withinThis As Rectangle, ByVal align As ContentAlignment) As Rectangle
        If ((align And anyRight) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.X = (withinThis.X _
                        + (withinThis.Width - alignThis.Width))
        ElseIf ((align And anyCenter) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.X = (withinThis.X _
                        + (((withinThis.Width - alignThis.Width) _
                        + 1) _
                        / 2))
        End If
        withinThis.Width = alignThis.Width
        Return withinThis
    End Function

    Private Function VAlignWithin(ByVal alignThis As Size, ByVal withinThis As Rectangle, ByVal align As ContentAlignment) As Rectangle
        If ((align And anyBottom) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.Y = (withinThis.Y _
                        + (withinThis.Height - alignThis.Height))
        ElseIf ((align And anyMiddle) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.Y = (withinThis.Y _
                        + (((withinThis.Height - alignThis.Height) _
                        + 1) _
                        / 2))
        End If
        withinThis.Height = alignThis.Height
        Return withinThis
    End Function

    Protected Overrides Sub OnCellMouseEnter(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex = -1 Then
            Header_Selected = e.ColumnIndex
        End If
        MyBase.OnCellMouseEnter(e)
    End Sub

    Protected Overrides Sub OnCellMouseLeave(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex = -1 Then
            Header_Selected = -1
        End If
        MyBase.OnCellMouseLeave(e)
    End Sub

    Protected Overrides Sub OnCellPainting(ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        Try
            If e.RowIndex = -1 Then
                If e.ColumnIndex = Header_Selected Then
                    Dim img As Image
                    img = My.Resources.DGHeaderrollover
                    Draw_Background(e.Graphics, img, e.CellBounds, 1)
                    Dim format1 As StringFormat
                    format1 = New StringFormat
                    format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                    Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

                    Dim txts As Size
                    txts = Drawing.Size.Empty
                    If (e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30) > Me.Columns(e.ColumnIndex).Width Then
                        Me.Columns(e.ColumnIndex).Width = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30
                    End If

                    txts = Drawing.Size.Ceiling(ef1)
                    e.CellBounds.Inflate(-4, -4)

                    Dim normalRegion As New Rectangle(e.CellBounds.Location.X + 1, e.CellBounds.Location.Y + 1, e.CellBounds.Size.Width - 22, e.CellBounds.Size.Height - 2)

                    normalRegion = HAlignWithin(txts, normalRegion, ContentAlignment.MiddleCenter)
                    normalRegion = VAlignWithin(txts, normalRegion, ContentAlignment.MiddleCenter)
                    Dim brush2 As Brush
                    format1 = New StringFormat
                    format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

                    brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

                    e.Graphics.DrawString(e.Value.ToString.ToUpper, Me.Font, brush2, normalRegion, format1)
                    brush2.Dispose()
                    Dim reCombobox_Columnsrder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
                    e.Graphics.DrawRectangle(Pens.LightSlateGray, reCombobox_Columnsrder)
                    drRegion = New Rectangle(e.CellBounds.Location.X + e.CellBounds.Size.Width - 23, e.CellBounds.Location.Y, 23, 23)
                    ComboBoxRenderer.DrawDropDownButton(e.Graphics, drRegion, VisualStyles.ComboBoxState.Normal)
                    e.Handled = True
                Else
                    If Not (Sort_Array Is Nothing) Then
                        If Array.IndexOf(Sort_Array, e.ColumnIndex) > -1 Then
                            Dim img As Image
                            img = My.Resources.DGHeaderrollover
                            Draw_Background(e.Graphics, img, e.CellBounds, 1)
                            Dim format1 As StringFormat
                            format1 = New StringFormat
                            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                            Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

                            Dim txts As Size
                            txts = Drawing.Size.Empty
                            If (e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 15) > Me.Columns(e.ColumnIndex).Width Then
                                Me.Columns(e.ColumnIndex).Width = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 15
                            End If

                            txts = Drawing.Size.Ceiling(ef1)
                            e.CellBounds.Inflate(-4, -4)

                            Dim normalRegion As New Rectangle(e.CellBounds.Location.X + 1, e.CellBounds.Location.Y + 1, e.CellBounds.Size.Width - 11, e.CellBounds.Size.Height - 2)

                            normalRegion = HAlignWithin(txts, normalRegion, ContentAlignment.MiddleCenter)
                            normalRegion = VAlignWithin(txts, normalRegion, ContentAlignment.MiddleCenter)
                            Dim brush2 As Brush
                            format1 = New StringFormat
                            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

                            brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

                            e.Graphics.DrawString(e.Value.ToString.ToUpper, Me.Font, brush2, CType(normalRegion, RectangleF), format1)
                            brush2.Dispose()
                            Dim reCombobox_Columnsrder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
                            e.Graphics.DrawRectangle(Pens.LightSlateGray, reCombobox_Columnsrder)
                            Dim sortRegion As New Rectangle(e.CellBounds.Location.X + e.CellBounds.Size.Width - 10, e.CellBounds.Location.Y, 9, 9)
                            Dim sSort() As String = Me.Binding_Source.Sort.Split(",")
                            For i As Integer = 0 To sSort.GetUpperBound(0)
                                If sSort(i).Contains(Me.Columns(e.ColumnIndex).DataPropertyName) Then
                                    If sSort(i).Contains("DESC") Then
                                        img = My.Resources.Arrowdown
                                    Else
                                        img = My.Resources.Arrowup
                                    End If
                                    Exit For
                                End If
                            Next
                            Draw_Background(e.Graphics, img, sortRegion, 1)
                            e.Handled = True
                        Else
                            Dim img As Image
                            img = My.Resources.DGheadernormal
                            Draw_Background(e.Graphics, img, e.CellBounds, 1)
                            Dim format1 As StringFormat
                            format1 = New StringFormat
                            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                            Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

                            Dim txts As Size
                            txts = Drawing.Size.Empty
                            If (e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30) > Me.Columns(e.ColumnIndex).Width Then
                                Me.Columns(e.ColumnIndex).Width = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30
                            End If

                            txts = Drawing.Size.Ceiling(ef1)
                            e.CellBounds.Inflate(-4, -4)

                            Dim txtr As Rectangle = e.CellBounds
                            txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                            txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                            Dim brush2 As Brush
                            format1 = New StringFormat
                            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

                            brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

                            e.Graphics.DrawString(e.Value.ToString.ToUpper, Me.Font, brush2, CType(txtr, RectangleF), format1)
                            brush2.Dispose()
                            Dim reCombobox_Columnsrder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
                            e.Graphics.DrawRectangle(Pens.LightSlateGray, reCombobox_Columnsrder)
                            e.Handled = True
                        End If
                    Else
                        If Not (Filter_Array Is Nothing) Then
                            If Array.IndexOf(Filter_Array, e.ColumnIndex) > -1 Then
                                Dim img As Image
                                img = My.Resources.DGHeaderrollover
                                Draw_Background(e.Graphics, img, e.CellBounds, 1)
                                Dim format1 As StringFormat
                                format1 = New StringFormat
                                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                                Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

                                Dim txts As Size
                                txts = Drawing.Size.Empty
                                If (e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30) > Me.Columns(e.ColumnIndex).Width Then
                                    Me.Columns(e.ColumnIndex).Width = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30
                                End If

                                txts = Drawing.Size.Ceiling(ef1)
                                e.CellBounds.Inflate(-4, -4)

                                Dim txtr As Rectangle = e.CellBounds
                                txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                                txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                                Dim brush2 As Brush
                                format1 = New StringFormat
                                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

                                brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

                                e.Graphics.DrawString(e.Value.ToString.ToUpper, Me.Font, brush2, CType(txtr, RectangleF), format1)
                                brush2.Dispose()
                                Dim reCombobox_Columnsrder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
                                e.Graphics.DrawRectangle(Pens.LightSlateGray, reCombobox_Columnsrder)
                                e.Handled = True
                            Else
                                Dim img As Image
                                img = My.Resources.DGheadernormal
                                Draw_Background(e.Graphics, img, e.CellBounds, 1)
                                Dim format1 As StringFormat
                                format1 = New StringFormat
                                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                                Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

                                Dim txts As Size
                                txts = Drawing.Size.Empty
                                If (e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30) > Me.Columns(e.ColumnIndex).Width Then
                                    Me.Columns(e.ColumnIndex).Width = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30
                                End If

                                txts = Drawing.Size.Ceiling(ef1)
                                e.CellBounds.Inflate(-4, -4)

                                Dim txtr As Rectangle = e.CellBounds
                                txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                                txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                                Dim brush2 As Brush
                                format1 = New StringFormat
                                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

                                brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

                                e.Graphics.DrawString(e.Value.ToString.ToUpper, Me.Font, brush2, CType(txtr, RectangleF), format1)
                                brush2.Dispose()
                                Dim reCombobox_Columnsrder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
                                e.Graphics.DrawRectangle(Pens.LightSlateGray, reCombobox_Columnsrder)
                                e.Handled = True
                            End If

                        Else
                            Dim img As Image
                            img = My.Resources.DGheadernormal
                            Draw_Background(e.Graphics, img, e.CellBounds, 1)
                            Dim format1 As StringFormat
                            format1 = New StringFormat
                            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                            Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

                            Dim txts As Size
                            txts = Drawing.Size.Empty
                            If (e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30) > Me.Columns(e.ColumnIndex).Width Then
                                Me.Columns(e.ColumnIndex).Width = e.Graphics.MeasureString(e.Value.ToString.ToUpper, Me.Font).Width + 30
                            End If

                            txts = Drawing.Size.Ceiling(ef1)
                            e.CellBounds.Inflate(-4, -4)

                            Dim txtr As Rectangle = e.CellBounds
                            txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                            txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
                            Dim brush2 As Brush
                            format1 = New StringFormat
                            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

                            brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

                            e.Graphics.DrawString(e.Value.ToString.ToUpper, Me.Font, brush2, CType(txtr, RectangleF), format1)
                            brush2.Dispose()
                            Dim reCombobox_Columnsrder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
                            e.Graphics.DrawRectangle(Pens.LightSlateGray, reCombobox_Columnsrder)
                            e.Handled = True
                        End If

                    End If

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub OnColumnHeaderMouseClick(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Dim rec As New Rectangle(New Point(Me.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Width - 23, 0), drRegion.Size)
        If rec.Contains(e.Location) Then
            iColumn_Clicked = e.ColumnIndex
            conMenu.Show(Me, New Point(Me.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).X + e.Location.X, Me.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Y))
            Header_Selected = -1
        End If
    End Sub

    Public Sub Bind_to_Bindingsource(ByVal bs As BindingSource)
        Try
            Me.Binding_Source = bs
            Me.DataSource = Me.Binding_Source
            Me.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            For Each dc As DataGridViewColumn In Me.Columns
                If dc IsNot Nothing Then
                    If dc.ValueType IsNot Nothing AndAlso dc.ValueType.ToString = "System.Int16" Then
                        Dim cs As New DataGridViewCellStyle
                        cs.Alignment = DataGridViewContentAlignment.MiddleRight
                        dc.DefaultCellStyle = cs
                    ElseIf dc.ValueType IsNot Nothing AndAlso dc.ValueType.ToString = "System.Int32" Then
                        Dim cs As New DataGridViewCellStyle
                        cs.Alignment = DataGridViewContentAlignment.MiddleRight
                        dc.DefaultCellStyle = cs
                    ElseIf dc.ValueType IsNot Nothing AndAlso dc.ValueType.ToString = "System.Double" Then
                        Dim cs As New DataGridViewCellStyle
                        cs.Alignment = DataGridViewContentAlignment.MiddleRight
                        cs.Format = "N2"
                        dc.DefaultCellStyle = cs
                    ElseIf dc.ValueType IsNot Nothing AndAlso dc.ValueType.ToString = "System.DateTime" Then
                        Dim cs As New DataGridViewCellStyle
                        cs.Alignment = DataGridViewContentAlignment.MiddleCenter
                        cs.Format = "d"
                        dc.DefaultCellStyle = cs
                    End If
                    If Not String.IsNullOrEmpty(dc.DataPropertyName) Then
                        dc.Name = dc.DataPropertyName
                    End If
                End If
            Next
        Catch ex As Exception
            Me.Binding_Source = Nothing
            Me.DataSource = Nothing
        End Try

    End Sub

    Public Sub SaveDatatoDatabase(ByVal cnString As String, ByVal e As System.Data.DataRowChangeEventArgs, ByVal naamTabel As String)
        Try
            s_SQL = ""
            sSQL = ""
            _Connection_String = cnString
            _e = e
            Dim i As Integer = 0
            cn = New SqlConnection(Connection_String)
            cn.Open()
            Dim dca() As DataColumn = Nothing
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT TOP 1 PERCENT * FROM [" & naamTabel & "]", cn)
            da.SelectCommand = cmd
            da.Fill(ds)
            da.FillSchema(dt, SchemaType.Source)
            Dim dgColumns() As String = Nothing
            For int As Integer = 0 To Me.Columns.Count - 1
                ReDim Preserve dgColumns(int)
                dgColumns(int) = Me.Columns(int).DataPropertyName.ToLower
            Next
            dca = dt.PrimaryKey

            If e.Row.RowState = DataRowState.Added Then
                For Each dc As DataColumn In dt.Columns
                    If Array.IndexOf(dgColumns, dc.ColumnName.ToLower) > -1 Then
                        If Not IsDBNull(e.Row.Item(dc.ColumnName)) Then
                            If dc.AutoIncrement = False Then
                                If s_SQL = "" Then
                                    s_SQL = "INSERT INTO [" & naamTabel & "] ([" & dc.ColumnName & "]"
                                Else
                                    s_SQL = s_SQL & ", [" & dc.ColumnName & "]"
                                End If
                                Select Case dc.DataType.ToString
                                    Case "System.String"
                                        If sSQL = "" Then
                                            sSQL = " SELECT '" & e.Row.Item(dc.ColumnName) & "' as expr" & i
                                        Else
                                            sSQL = sSQL & ", '" & e.Row.Item(dc.ColumnName) & "' as expr" & i
                                        End If
                                    Case "System.Boolean"
                                        If sSQL = "" Then
                                            sSQL = " SELECT " & Microsoft.VisualBasic.IIf(e.Row.Item(dc.ColumnName) = True, 1, 0) & " as expr" & i
                                        Else
                                            sSQL = sSQL & ", " & Microsoft.VisualBasic.IIf(e.Row.Item(dc.ColumnName) = True, 1, 0) & " as expr" & i
                                        End If
                                    Case "System.DateTime"
                                        Dim dteTmp As Date = DateTime.Parse(e.Row.Item(dc.ColumnName).ToString)
                                        If sSQL = "" Then
                                            sSQL = " SELECT CONVERT(Datetime, '" & dteTmp.Year & "/" & dteTmp.Month & "/" & dteTmp.Day & "', 101) as expr" & i
                                        Else
                                            sSQL = sSQL & ", CONVERT(Datetime, '" & dteTmp.Year & "/" & dteTmp.Month & "/" & dteTmp.Day & "', 101) as expr" & i
                                        End If
                                    Case "System.Double"
                                        If sSQL = "" Then
                                            sSQL = " SELECT " & e.Row.Item(dc.ColumnName).ToString.Replace(",", ".") & " as expr" & i
                                        Else
                                            sSQL = sSQL & ", " & e.Row.Item(dc.ColumnName).ToString.Replace(",", ".") & " as expr" & i
                                        End If
                                    Case "System.Int16"
                                        If sSQL = "" Then
                                            sSQL = " SELECT " & e.Row.Item(dc.ColumnName) & " as expr" & i
                                        Else
                                            sSQL = sSQL & ", " & e.Row.Item(dc.ColumnName) & " as expr" & i
                                        End If
                                    Case "System.Int32"
                                        If sSQL = "" Then
                                            sSQL = " SELECT " & e.Row.Item(dc.ColumnName) & " as expr" & i
                                        Else
                                            sSQL = sSQL & ", " & e.Row.Item(dc.ColumnName) & " as expr" & i
                                        End If
                                End Select
                                i += 1
                            End If
                        End If
                    End If
                Next
                da.Dispose()

                If Not s_SQL = "" Then
                    s_SQL = s_SQL & ") " & sSQL
                    cmd = New SqlCommand(s_SQL, cn)
                    cmd.ExecuteNonQuery()
                    e.Row.AcceptChanges()
                End If
            ElseIf e.Row.RowState = DataRowState.Modified Then
                For Each dc As DataColumn In dt.Columns
                    If Array.IndexOf(dgColumns, dc.ColumnName.ToLower) > -1 Then
                        If Not IsDBNull(e.Row.Item(dc.ColumnName, DataRowVersion.Current)) Then
                            Select Case dc.DataType.ToString
                                Case "System.String"
                                    If sSQL = "" Then
                                        sSQL = "UPDATE [" & naamTabel & "] SET [" & dc.ColumnName & "]='" & e.Row.Item(dc.ColumnName, DataRowVersion.Current) & "'"
                                    Else
                                        sSQL = sSQL & ", [" & dc.ColumnName & "]='" & e.Row.Item(dc.ColumnName, DataRowVersion.Current) & "'"
                                    End If
                                    If Array.IndexOf(dca, dc) > -1 Then
                                        If s_SQL = "" Then
                                            s_SQL = " WHERE ([" & dc.ColumnName & "]='" & e.Row.Item(dc.ColumnName, DataRowVersion.Original) & "') "
                                        Else
                                            s_SQL = s_SQL & "AND ([" & dc.ColumnName & "]='" & e.Row.Item(dc.ColumnName, DataRowVersion.Original) & "') "
                                        End If
                                    End If
                                Case "System.Boolean"
                                    If sSQL = "" Then
                                        sSQL = "UPDATE [" & naamTabel & "] SET [" & dc.ColumnName & "]=" & Microsoft.VisualBasic.IIf(e.Row.Item(dc.ColumnName, DataRowVersion.Current) = True, 1, 0)
                                    Else
                                        sSQL = sSQL & ", [" & dc.ColumnName & "]=" & Microsoft.VisualBasic.IIf(e.Row.Item(dc.ColumnName, DataRowVersion.Current) = True, 1, 0)
                                    End If
                                Case "System.DateTime"
                                    Dim dteTmp As Date = DateTime.Parse(e.Row.Item(dc.ColumnName).ToString)
                                    If sSQL = "" Then
                                        sSQL = "UPDATE [" & naamTabel & "] SET [" & dc.ColumnName & "]= CONVERT(Datetime, '" & dteTmp.Year & "/" & dteTmp.Month & "/" & dteTmp.Day & "', 101)"
                                    Else
                                        sSQL = sSQL & ", [" & dc.ColumnName & "]= CONVERT(Datetime, '" & dteTmp.Year & "/" & dteTmp.Month & "/" & dteTmp.Day & "', 101)"
                                    End If
                                    If Array.IndexOf(dca, dc) > -1 Then
                                        If s_SQL = "" Then
                                            s_SQL = " WHERE ([" & dc.ColumnName & "]=CONVERT(Datetime, '" & dteTmp.Year & "/" & dteTmp.Month & "/" & dteTmp.Day & "', 101)) "
                                        Else
                                            s_SQL = s_SQL & "AND ([" & dc.ColumnName & "]=CONVERT(Datetime, '" & dteTmp.Year & "/" & dteTmp.Month & "/" & dteTmp.Day & "', 101)) "
                                        End If
                                    End If
                                Case "System.Double"
                                    If sSQL = "" Then
                                        sSQL = "UPDATE [" & naamTabel & "] SET [" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Current).ToString.Replace(",", ".")
                                    Else
                                        sSQL = sSQL & ", [" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Current).ToString.Replace(",", ".")
                                    End If
                                Case "System.Int16"
                                    If dc.AutoIncrement = False Then
                                        If sSQL = "" Then
                                            sSQL = "UPDATE [" & naamTabel & "] SET [" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Current)
                                        Else
                                            sSQL = sSQL & ", [" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Current)
                                        End If
                                    End If

                                    If Array.IndexOf(dca, dc) > -1 Then
                                        If s_SQL = "" Then
                                            s_SQL = " WHERE ([" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Original) & ") "
                                        Else
                                            s_SQL = s_SQL & "AND ([" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Original) & ") "
                                        End If
                                    End If
                                Case "System.Int32"
                                    If dc.AutoIncrement = False Then
                                        If sSQL = "" Then
                                            sSQL = "UPDATE [" & naamTabel & "] SET [" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Current)
                                        Else
                                            sSQL = sSQL & ", [" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Current)
                                        End If
                                    End If

                                    If Array.IndexOf(dca, dc) > -1 Then
                                        If s_SQL = "" Then
                                            s_SQL = " WHERE ([" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Original) & ") "
                                        Else
                                            s_SQL = s_SQL & "AND ([" & dc.ColumnName & "]=" & e.Row.Item(dc.ColumnName, DataRowVersion.Original) & ") "
                                        End If
                                    End If
                            End Select
                        End If
                    End If
                Next
                da.Dispose()
                If Not sSQL = "" Then
                    s_SQL = sSQL & s_SQL
                    cmd = New SqlCommand(s_SQL, cn)
                    cmd.ExecuteNonQuery()
                    e.Row.AcceptChanges()
                End If
            End If
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub conMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles conMenu.Opening
        If Me.Columns(iColumn_Clicked).ValueType Is Type.GetType("System.Boolean") Then
            Me.conTooltext.Visible = False
            Me.ContoolValue.Visible = False
            Me.contoolYesNo.Visible = True
            Me.ContoolDate.Visible = False
        Else
            If Me.Columns(iColumn_Clicked).ValueType Is Type.GetType("System.Double") Then
                Me.SearchValueGreater.Visible = True
                Me.SearchValueSmaller.Visible = True
                Me.conTooltext.Visible = False
                Me.ContoolValue.Visible = True
                Me.contoolYesNo.Visible = False
                Me.ContoolDate.Visible = False
            Else
                If Me.Columns(iColumn_Clicked).ValueType Is Type.GetType("System.Int32") Then
                    Me.SearchValueGreater.Visible = True
                    Me.SearchValueSmaller.Visible = True
                    Me.conTooltext.Visible = False
                    Me.ContoolValue.Visible = True
                    Me.contoolYesNo.Visible = False
                    Me.ContoolDate.Visible = False
                Else
                    If Me.Columns(iColumn_Clicked).ValueType Is Type.GetType("System.DateTime") Then
                        Me.SearchDateGreater.Visible = True
                        Me.SearchDateSmaller.Visible = True
                        Me.conTooltext.Visible = False
                        Me.ContoolValue.Visible = False
                        Me.contoolYesNo.Visible = False
                        Me.ContoolDate.Visible = True
                    Else
                        Me.SearchTextbox1.Visible = True
                        Me.conTooltext.Visible = True
                        Me.ContoolValue.Visible = False
                        Me.contoolYesNo.Visible = False
                        Me.ContoolDate.Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SearchTextbox1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchTextbox1.VisibleChanged
        Create_Filtertext()
    End Sub

    Private Sub Create_Filtertext()
        Try
            If Me.SearchTextbox1.Visible = False Then
                If SearchTextbox1.Text <> "" Then
                    Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] LIKE ", SearchTextbox1.Text, True, True)
                    Me.conMenu.Close()
                    SearchTextbox1.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FilterOnTrue()
        Try
            Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]=", "True", False, False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FilterOnFalse()
        Try
            Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]=", "False", False, False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Apply_Filter(ByVal controlestring As String, ByVal waardestring As String, ByVal IsString As Boolean, ByVal blLike As Boolean)

        Dim sFltr As String = Me.Binding_Source.Filter
        If sFltr <> "" Then
            Dim fltrs() As String = Split(sFltr, " AND ", , CompareMethod.Text)
            Dim iFound As Integer = -1
            For i As Integer = 0 To fltrs.GetUpperBound(0)
                If fltrs(i).Contains(controlestring) Then
                    iFound = i
                    Exit For
                End If
            Next
            Dim sNewFilter As String = ""
            If iFound > -1 Then
                For i As Integer = 0 To fltrs.GetUpperBound(0)
                    If i = iFound Then
                        If sNewFilter = "" Then
                            If IsString = True Then
                                If blLike = True Then
                                    sNewFilter = controlestring & "'%" & waardestring & "%'"
                                Else
                                    sNewFilter = controlestring & "'" & waardestring & "'"
                                End If
                            Else
                                sNewFilter = controlestring & waardestring
                            End If
                        Else
                            If IsString = True Then
                                If blLike = True Then
                                    sNewFilter = sNewFilter & " AND " & controlestring & "'%" & waardestring & "%'"
                                Else
                                    sNewFilter = sNewFilter & " AND " & controlestring & "'" & waardestring & "'"
                                End If
                            Else
                                sNewFilter = sNewFilter & " AND " & controlestring & waardestring
                            End If
                        End If
                    Else
                        If sNewFilter = "" Then
                            sNewFilter = fltrs(i)
                        Else
                            sNewFilter = sNewFilter & " AND " & fltrs(i)
                        End If
                    End If
                Next
            Else
                For i As Integer = 0 To fltrs.GetUpperBound(0)
                    If sNewFilter = "" Then
                        sNewFilter = fltrs(i)
                    Else
                        sNewFilter = sNewFilter & " AND " & fltrs(i)
                    End If
                Next
                If sNewFilter = "" Then
                    If IsString = True Then
                        If blLike = True Then
                            sNewFilter = controlestring & "'%" & waardestring & "%'"
                        Else
                            sNewFilter = controlestring & "'" & waardestring & "'"
                        End If
                    Else
                        sNewFilter = controlestring & waardestring
                    End If
                Else
                    If IsString = True Then
                        If blLike = True Then
                            sNewFilter = sNewFilter & " AND " & controlestring & "'%" & waardestring & "%'"
                        Else
                            sNewFilter = sNewFilter & " AND " & controlestring & "'" & waardestring & "'"
                        End If
                    Else
                        sNewFilter = sNewFilter & " AND " & controlestring & waardestring
                    End If
                End If
            End If
            Me.Binding_Source.Filter = sNewFilter
        Else
            If IsString = True Then
                If blLike = True Then
                    Me.Binding_Source.Filter = controlestring & "'%" & waardestring & "%'"
                Else
                    Me.Binding_Source.Filter = controlestring & "'" & waardestring & "'"
                End If
            Else
                Me.Binding_Source.Filter = controlestring & waardestring
            End If
        End If
        If Not (Filter_Array Is Nothing) Then
            Dim iFilter As Integer = Filter_Array.GetUpperBound(0) + 1
            ReDim Preserve Filter_Array(iFilter)
            Filter_Array(iFilter) = iColumn_Clicked
        Else
            ReDim Preserve Filter_Array(0)
            Filter_Array(0) = iColumn_Clicked
        End If
    End Sub

    Private Sub contoolYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contoolYes.Click
        FilterOnTrue()
    End Sub

    Private Sub contoolNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contoolNo.Click
        FilterOnFalse()
    End Sub


    Private Sub ToolFilternull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFilternull.Click
        Try
            Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] ", "IS NULL", False, False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchValueSmaller_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchValueSmaller.VisibleChanged
        Create_FiltertextSmaller()
    End Sub

    Private Sub Create_FiltertextSmaller()
        Try
            If Me.SearchValueSmaller.Visible = False Then
                If SearchValueSmaller.Text <> "" Then
                    Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] < ", SearchValueSmaller.Text.Replace(",", "."), False, False)
                    Me.conMenu.Close()
                    SearchValueSmaller.Text = ""      'Toegevoegd 1.0.0.10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchValueGreater_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchValueGreater.VisibleChanged
        Create_FiltertextGreater()
    End Sub

    Private Sub Create_FiltertextGreater()
        Try
            If Me.SearchValueGreater.Visible = False Then
                If SearchValueGreater.Text <> "" Then
                    Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] > ", SearchValueGreater.Text.Replace(",", "."), False, False)
                    Me.conMenu.Close()
                    SearchValueGreater.Text = ""      'Toegevoegd 1.0.0.10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchDateGreater_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchDateGreater.VisibleChanged
        Create_FiltertextGreaterDate()
    End Sub

    Private Sub Create_FiltertextGreaterDate()
        Try
            If Me.SearchDateGreater.Visible = False Then
                If SearchDateGreater.Text <> "" Then
                    Dim dteZoek As Date
                    If DateTime.TryParse(SearchDateGreater.Text, dteZoek) = True Then
                        Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] > ", String.Format("#{0:M/dd/yyyy}#", dteZoek), False, False)
                    Else

                    End If
                    Me.conMenu.Close()
                    SearchDateGreater.Text = ""      'Toegevoegd 1.0.0.10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchDateSmaller_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchDateSmaller.VisibleChanged
        Create_FiltertextSmallerDate()
    End Sub

    Private Sub Create_FiltertextSmallerDate()
        Try
            If Me.SearchDateSmaller.Visible = False Then
                If SearchDateSmaller.Text <> "" Then
                    Dim dteZoek As Date
                    If DateTime.TryParse(SearchDateSmaller.Text, dteZoek) = True Then
                        Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] < ", String.Format("#{0:M/dd/yyyy}#", dteZoek), False, False)
                    Else

                    End If
                    Me.conMenu.Close()
                    SearchDateSmaller.Text = ""      'Toegevoegd 1.0.0.10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolFilternotnull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFilternotnull.Click
        Try
            Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] ", "IS NOT NULL", False, False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SortAsc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortAsc.Click
        Try
            If Me.Binding_Source.Sort = "" Then
                Me.Binding_Source.Sort = "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]"
                ReDim Preserve Sort_Array(0)
                Sort_Array(0) = iColumn_Clicked
            Else
                Dim sSort() As String = Me.Binding_Source.Sort.Split(",")
                Me.Binding_Source.Sort = ""
                Dim blBestaat As Boolean = False
                For i As Integer = 0 To sSort.GetUpperBound(0)
                    If sSort(i).Contains("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]") Then
                        blBestaat = True
                        If Me.Binding_Source.Sort = "" Then
                            Me.Binding_Source.Sort = "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]"
                        Else
                            Me.Binding_Source.Sort = Me.Binding_Source.Sort & ",[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]"
                        End If
                    Else
                        If Me.Binding_Source.Sort = "" Then
                            Me.Binding_Source.Sort = sSort(i)
                        Else
                            Me.Binding_Source.Sort = Me.Binding_Source.Sort & "," & sSort(i)
                        End If
                    End If
                Next
                If blBestaat = False Then
                    If Me.Binding_Source.Sort = "" Then
                        Me.Binding_Source.Sort = "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]"
                    Else
                        Me.Binding_Source.Sort = Me.Binding_Source.Sort & ",[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]"
                    End If
                    If Not (Sort_Array Is Nothing) Then
                        Dim iSort As Integer = Sort_Array.GetUpperBound(0) + 1
                        ReDim Preserve Sort_Array(iSort)
                        Sort_Array(iSort) = iColumn_Clicked
                    Else
                        ReDim Preserve Sort_Array(0)
                        Sort_Array(0) = iColumn_Clicked
                    End If
                Else
                    If (Sort_Array Is Nothing) Then
                        ReDim Preserve Sort_Array(0)
                        Sort_Array(0) = iColumn_Clicked
                    Else
                        Dim iSort As Integer = Sort_Array.GetUpperBound(0) + 1
                        ReDim Preserve Sort_Array(iSort)
                        Sort_Array(iSort) = iColumn_Clicked
                    End If
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SortNone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortNone.Click
        Try
            If Me.Binding_Source.Sort <> "" Then
                Dim sSort() As String = Me.Binding_Source.Sort.Split(",")
                If Not (sSort Is Nothing) Then
                    Me.Binding_Source.Sort = ""
                    For i As Integer = 0 To sSort.GetUpperBound(0)
                        If sSort(i).Replace(" DESC", "") <> "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]" Then
                            If Me.Binding_Source.Sort = "" Then
                                Me.Binding_Source.Sort = sSort(i)
                            Else
                                Me.Binding_Source.Sort = Me.Binding_Source.Sort & "," & sSort(i)
                            End If
                        End If
                    Next
                    Dim iSort() As Integer = Nothing
                    Dim iCnt As Integer = 0
                    If Not (Sort_Array Is Nothing) Then
                        For i As Integer = 0 To Sort_Array.GetUpperBound(0)
                            If Not (Sort_Array(i) = iColumn_Clicked) Then
                                ReDim Preserve iSort(iCnt)
                                iSort(iCnt) = Sort_Array(i)
                                iCnt += 1
                            End If
                        Next
                        Sort_Array = iSort
                    End If

                End If
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub SortDesc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortDesc.Click
        Try
            If Me.Binding_Source.Sort = "" Then
                Me.Binding_Source.Sort = "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] DESC"
                ReDim Preserve Sort_Array(0)
                Sort_Array(0) = iColumn_Clicked
            Else
                Dim sSort() As String = Me.Binding_Source.Sort.Split(",")
                Me.Binding_Source.Sort = ""
                Dim blBestaat As Boolean = False
                For i As Integer = 0 To sSort.GetUpperBound(0)
                    If sSort(i).Contains("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "]") Then
                        blBestaat = True
                        If Me.Binding_Source.Sort = "" Then
                            Me.Binding_Source.Sort = "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] DESC"
                        Else
                            Me.Binding_Source.Sort = Me.Binding_Source.Sort & ",[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] DESC"
                        End If
                    Else
                        If Me.Binding_Source.Sort = "" Then
                            Me.Binding_Source.Sort = sSort(i)
                        Else
                            Me.Binding_Source.Sort = Me.Binding_Source.Sort & "," & sSort(i)
                        End If
                    End If
                Next
                If blBestaat = False Then
                    If Me.Binding_Source.Sort = "" Then
                        Me.Binding_Source.Sort = "[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] DESC"
                    Else
                        Me.Binding_Source.Sort = Me.Binding_Source.Sort & ",[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] DESC"
                    End If
                    If Not (Sort_Array Is Nothing) Then
                        Dim iSort As Integer = Sort_Array.GetUpperBound(0) + 1
                        ReDim Preserve Sort_Array(iSort)
                        Sort_Array(iSort) = iColumn_Clicked
                    Else
                        ReDim Preserve Sort_Array(0)
                        Sort_Array(0) = iColumn_Clicked
                    End If
                Else
                    If (Sort_Array Is Nothing) Then
                        ReDim Preserve Sort_Array(0)
                        Sort_Array(0) = iColumn_Clicked
                    Else
                        Dim iSort As Integer = Sort_Array.GetUpperBound(0) + 1
                        ReDim Preserve Sort_Array(iSort)
                        Sort_Array(iSort) = iColumn_Clicked
                    End If
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SearchValueEqual_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchValueEqual.VisibleChanged
        Create_FiltertextEqual()
    End Sub

    Private Sub Create_FiltertextEqual()
        Try
            If Me.SearchValueEqual.Visible = False Then
                If SearchValueEqual.Text <> "" Then
                    Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] = ", SearchValueEqual.Text.Replace(",", "."), False, False)
                    Me.conMenu.Close()
                    SearchValueEqual.Text = ""      'Toegevoegd 1.0.0.10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchDateEqual_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchDateEqual.VisibleChanged
        Create_FiltertextDateEqual()
    End Sub

    Private Sub Create_FiltertextDateEqual()
        Try
            If Me.SearchDateEqual.Visible = False Then
                If SearchDateEqual.Text <> "" Then
                    Apply_Filter("[" & Me.Columns(Me.iColumn_Clicked).DataPropertyName & "] = ", SearchDateEqual.Text, False, False)
                    Me.conMenu.Close()
                    SearchDateEqual.Text = ""      'Toegevoegd 1.0.0.10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolFilterNone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolFilterNone.Click
        Me.Binding_Source.Filter = ""
        Me.Sort_Array = Nothing
        Me.Filter_Array = Nothing
        Me.Header_Selected = -1
    End Sub
End Class
