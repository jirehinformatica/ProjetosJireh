Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ComboboxMultipleColumn
    Inherits System.Windows.Forms.ComboBox


#Region " Globals "
    Enum styles
        officeXP
        office2003
    End Enum

    Enum states
        normal
        focused
        dropeddown
        disabled
    End Enum

    Private _Not_inList As Boolean = False
    Private mLeavingEventlist As ArrayList
    Private mNot_inListEventlist As ArrayList
    Private mIndexchangedEventlist As ArrayList

    Public Event Not_inListChanged()

    Private _Data_Table As DataTable
    Private _Column_Widths As String
    Private _DoNotReact As Boolean = False
    Private _Textchanged As Boolean = False
    Private _Column_Values() As String

    Dim style As styles = styles.office2003
    Dim state As states = states.normal
    Dim BorderPen As Pen
    Dim ArrowBrush, ButtonBrush, TextBrush As Brush
    Dim MainRect As Rectangle
    Dim ButtonSurRect As Rectangle
    Dim ButtonRect As Rectangle
    Dim pntArrow(2) As PointF
    Dim VerticalMiddle As Integer
    Dim ArrowPath As GraphicsPath = New GraphicsPath
    Dim TextLocation As PointF
    Dim g As Graphics
    Private _Back_Ground As Color = Color.White
#End Region


#Region " Listener "

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
    End Function

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        Select Case m.Msg

            Case &HF
                If Me.DropDownStyle = ComboBoxStyle.Simple Then Exit Sub
                g = Me.CreateGraphics
                If Me.Enabled Then
                    g.Clear(Back_Ground)
                Else
                    g.Clear(Color.FromName("control"))
                End If
                DrawButton(g)
                DrawArrow(g)
                DrawBorder(g)
                DrawText(g)

            Case 7, 8, &H7, &H8, &H200, &H2A3
                UpdateState()

        End Select

    End Sub

    Private Sub FlatComboBox_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
        UpdateState()
    End Sub

    Private WithEvents Timer As Timer = New Timer

    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick
        UpdateState()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal e As Boolean)
        Me.Timer.Enabled = False
        MyBase.Dispose(e)
    End Sub

    Private Sub UpdateState()
        'save the current state
        Dim temp As states = state
        '
        If Me.Enabled Then
            If Me.DroppedDown Then
                Me.state = states.dropeddown
            Else
                If ClientRectangle.Contains(PointToClient(Control.MousePosition)) Then
                    Me.state = states.focused
                ElseIf Me.Focused Then
                    Me.state = states.focused
                Else
                    Me.state = states.normal
                End If
            End If
        Else
            Me.state = states.disabled
        End If
        If state <> temp Then
            Me.Invalidate()
        End If
    End Sub
#End Region

#Region " Public property's "

    Public Property Back_Ground() As Color
        Get
            Return _Back_Ground
        End Get
        Set(ByVal value As Color)
            _Back_Ground = value
        End Set
    End Property


    Public Property FlatComboStyle() As styles
        Get
            Return style
        End Get
        Set(ByVal Value As styles)
            style = Value
        End Set
    End Property

    Public Property Column_Values() As String()
        Get
            Return _Column_Values
        End Get
        Set(ByVal value As String())
            _Column_Values = value
        End Set
    End Property

    Public Property Data_Table() As DataTable
        Get
            Return _Data_Table
        End Get
        Set(ByVal value As DataTable)
            _Data_Table = value
        End Set
    End Property

    Public Property Column_Widths() As String
        Get
            Return _Column_Widths
        End Get
        Set(ByVal value As String)
            _Column_Widths = value
        End Set
    End Property

    Public Property Not_inList() As Boolean
        Get
            Return _Not_inList
        End Get
        Set(ByVal value As Boolean)
            _Not_inList = value
        End Set
    End Property
#End Region

#Region " Drawing functions "

    Private Sub Draw_Rounded_Rectangle(ByVal g As Graphics, ByVal pen As Pen, ByVal rectangle As Rectangle, ByVal radius As Single)
        Dim size As Single = (radius * 2.0!)
        Dim gp As GraphicsPath = New GraphicsPath
        gp.AddArc(rectangle.X, rectangle.Y, size, size, 180, 90)
        gp.AddArc((rectangle.X _
                        + (rectangle.Width - size)), rectangle.Y, size, size, 270, 90)
        gp.AddArc((rectangle.X _
                        + (rectangle.Width - size)), (rectangle.Y _
                        + (rectangle.Height - size)), size, size, 0, 90)
        gp.AddArc(rectangle.X, (rectangle.Y _
                        + (rectangle.Height - size)), size, size, 90, 90)
        gp.CloseFigure()
        g.DrawPath(pen, gp)
        gp.Dispose()
    End Sub

    Private Sub Fill_Rounded_Rectangle(ByVal g As Graphics, ByVal brush As Brush, ByVal rectangle As Rectangle, ByVal radius As Single)
        Dim size As Single = (radius * 2.0!)
        Dim gp As GraphicsPath = New GraphicsPath
        gp.AddArc(rectangle.X, rectangle.Y, size, size, 180, 90)
        gp.AddArc((rectangle.X _
                        + (rectangle.Width - size)), rectangle.Y, size, size, 270, 90)
        gp.AddArc((rectangle.X _
                        + (rectangle.Width - size)), (rectangle.Y _
                        + (rectangle.Height - size)), size, size, 0, 90)
        gp.AddArc(rectangle.X, (rectangle.Y _
                        + (rectangle.Height - size)), size, size, 90, 90)
        gp.CloseFigure()
        g.FillPath(brush, gp)
        gp.Dispose()
    End Sub

    Private Sub Render_Selection(ByVal g As Graphics, ByVal rec As Rectangle, ByVal radius As Single, ByVal sel As Boolean)
        Dim col() As Color = New Color() {Color.FromArgb(255, 254, 227), Color.FromArgb(255, 231, 151), Color.FromArgb(255, 215, 80), Color.FromArgb(255, 231, 150)}
        Dim pos() As Single = New Single() {0.0!, 0.4!, 0.4!, 1.0!}
        Dim blend As ColorBlend = New ColorBlend
        blend.Colors = col
        blend.Positions = pos

        If sel = True Then
            Dim brush As LinearGradientBrush = New LinearGradientBrush(rec, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical)
            brush.InterpolationColors = blend
            Fill_Rounded_Rectangle(g, brush, rec, 2.0!)
            Draw_Rounded_Rectangle(g, New Pen(Color.FromArgb(251, 140, 60)), rec, radius)
            rec.Offset(1, 1)
            rec.Width = (rec.Width - 2)
            rec.Height = (rec.Height - 2)
            Draw_Rounded_Rectangle(g, New Pen(New LinearGradientBrush(rec, Color.FromArgb(255, 255, 247), Color.Transparent, LinearGradientMode.ForwardDiagonal)), rec, 2.0!)
        Else
            Fill_Rounded_Rectangle(g, New SolidBrush(Back_Ground), rec, 2.0!)
            Draw_Rounded_Rectangle(g, New Pen(Back_Ground), rec, radius)
            rec.Offset(1, 1)
            rec.Width = (rec.Width - 2)
            rec.Height = (rec.Height - 2)
            Draw_Rounded_Rectangle(g, New Pen(Back_Ground), rec, 2.0!)
        End If


    End Sub

    Private Sub DrawButton(ByVal g As Graphics)
        If Me.RightToLeft = Windows.Forms.RightToLeft.No Then
            ButtonRect = New Rectangle(Me.Width - 18, 1, 17, Me.Height - 2)
        Else
            ButtonRect = New Rectangle(1, 1, 17, Me.Height - 2)
        End If
        Select Case state
            Case states.normal
                Select Case style
                    Case styles.officeXP
                        ButtonBrush = New SolidBrush(Color.FromName("control"))
                    Case styles.office2003
                        ButtonBrush = New LinearGradientBrush(ButtonRect, Color.FromArgb(214, 232, 253), Color.FromArgb(156, 189, 235), LinearGradientMode.Vertical)
                End Select
            Case states.focused
                Select Case style
                    Case styles.officeXP
                        ButtonBrush = New SolidBrush(Color.FromArgb(193, 210, 238))
                    Case styles.office2003
                        ButtonBrush = New LinearGradientBrush(ButtonRect, Color.FromArgb(255, 242, 200), Color.FromArgb(255, 210, 148), LinearGradientMode.Vertical)
                End Select
            Case states.dropeddown
                Select Case style
                    Case styles.officeXP
                        ButtonBrush = New SolidBrush(Color.FromArgb(152, 181, 226))
                    Case styles.office2003
                        ButtonBrush = New LinearGradientBrush(ButtonRect, Color.FromArgb(254, 149, 82), Color.FromArgb(255, 207, 139), LinearGradientMode.Vertical)
                End Select
            Case states.disabled
                ButtonBrush = New SolidBrush(Color.FromName("control"))
        End Select
        g.FillRectangle(ButtonBrush, ButtonRect)

    End Sub

    Private Sub DrawArrow(ByVal g As Graphics)
        VerticalMiddle = CInt(Me.Height / 2)
        If Me.RightToLeft = Windows.Forms.RightToLeft.No Then
            pntArrow(0) = New PointF(Me.Width - 11, VerticalMiddle - 1)
            pntArrow(1) = New PointF(Me.Width - 9, VerticalMiddle + 2)
            pntArrow(2) = New PointF(Me.Width - 6, VerticalMiddle - 1)
        Else
            pntArrow(0) = New PointF(7, VerticalMiddle - 1)
            pntArrow(1) = New PointF(9, VerticalMiddle + 2)
            pntArrow(2) = New PointF(12, VerticalMiddle - 1)
        End If
        Select Case Me.state
            Case states.normal, states.focused
                ArrowBrush = New SolidBrush(Color.FromArgb(86, 125, 177))
            Case states.dropeddown
                Select Case Me.style
                    Case styles.officeXP
                        ArrowBrush = New SolidBrush(Color.FromArgb(73, 73, 73))
                    Case styles.office2003
                        ArrowBrush = New SolidBrush(Color.Black)
                End Select
            Case states.disabled
                ArrowBrush = New SolidBrush(Color.DarkGray)
        End Select
        g.FillPolygon(ArrowBrush, pntArrow)
    End Sub

    Private Sub DrawBorder(ByVal g As Graphics)
        MainRect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        If Me.RightToLeft Then
            ButtonSurRect = New Rectangle(0, 0, ButtonRect.Width + 1, ButtonRect.Height + 1)
        Else
            ButtonSurRect = New Rectangle(ButtonRect.X - 1, ButtonRect.Y - 1, ButtonRect.Width + 2, ButtonRect.Height + 2)
        End If
        Select Case state
            Case states.focused, states.dropeddown
                Select Case Me.style
                    Case styles.officeXP
                        BorderPen = New Pen(Color.FromArgb(49, 106, 197))
                    Case styles.office2003
                        BorderPen = New Pen(Color.Blue)
                End Select
            Case states.disabled
                BorderPen = New Pen(Color.DarkGray)
            Case states.normal
                BorderPen = New Pen(Color.DimGray)
            Case Else
                Exit Sub
        End Select
        If Not state = states.disabled Then g.DrawRectangle(BorderPen, ButtonSurRect)

        Draw_Rounded_Rectangle(g, BorderPen, MainRect, 2.0!)

    End Sub

    Private Sub DrawText(ByVal g As Graphics)
        If Me.DropDownStyle <> ComboBoxStyle.DropDownList Then Exit Sub
        Dim text As String = ""
        Select Case state
            Case states.normal, states.focused, states.dropeddown
                TextBrush = New SolidBrush(Me.ForeColor)
            Case states.disabled
                TextBrush = New SolidBrush(Color.DarkGray)
        End Select
        If g.MeasureString(Me.Text, Me.Font).Width > Me.Width - 30 Then
            Dim i As Integer = -1
            Do
                i += 1
                If g.MeasureString(text, Me.Font).Width > Me.Width - 30 Then Exit Do
                text &= Me.Text.Substring(i, 1)
            Loop
        Else
            text = Me.Text
        End If
        If Me.RightToLeft = Windows.Forms.RightToLeft.No Then
            TextLocation = New PointF(1, 4)
        Else
            Dim temp As Single = Me.Width - (g.MeasureString(text, Me.Font).Width)
            TextLocation = New PointF(temp, 4)
        End If
        g.DrawString(text, Me.Font, TextBrush, TextLocation)
    End Sub
#End Region

#Region "Events"

    Public Custom Event On_Index_Changed As EventHandler
        AddHandler(ByVal value As EventHandler)
            If mIndexchangedEventlist Is Nothing Then
                mIndexchangedEventlist = New ArrayList
            End If
            mIndexchangedEventlist.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            mIndexchangedEventlist.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal ea As EventArgs)
            If mIndexchangedEventlist IsNot Nothing Then
                For Each handler As EventHandler In mIndexchangedEventlist
                    If handler IsNot Nothing Then
                        handler.BeginInvoke(sender, ea, Nothing, Nothing)
                    End If
                Next
            End If
        End RaiseEvent
    End Event

    Public Custom Event On_Leaving As EventHandler
        AddHandler(ByVal value As EventHandler)
            If mLeavingEventlist Is Nothing Then
                mLeavingEventlist = New ArrayList
            End If
            mLeavingEventlist.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            mLeavingEventlist.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal ea As EventArgs)
            If mLeavingEventlist IsNot Nothing Then
                For Each handler As EventHandler In mLeavingEventlist
                    If handler IsNot Nothing Then
                        handler.BeginInvoke(sender, ea, Nothing, Nothing)
                    End If
                Next
            End If
        End RaiseEvent
    End Event

    Public Custom Event On_Not_In_List As EventHandler
        AddHandler(ByVal value As EventHandler)
            If mNot_inListEventlist Is Nothing Then
                mNot_inListEventlist = New ArrayList
            End If
            mNot_inListEventlist.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            mNot_inListEventlist.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal ea As EventArgs)
            If mNot_inListEventlist IsNot Nothing Then
                For Each handler As EventHandler In mNot_inListEventlist
                    If handler IsNot Nothing Then
                        handler.BeginInvoke(sender, ea, Nothing, Nothing)
                    End If
                Next
            End If
        End RaiseEvent
    End Event

    Public Sub Not_inListChange() Handles MyClass.Not_inListChanged

    End Sub
#End Region

#Region "Initialisation"
    Sub New()
        MyBase.New()
        MyBase.DrawMode = DrawMode.OwnerDrawFixed
        Timer.Interval = 20
        Timer.Enabled = True
    End Sub

    Public Sub Column_Widthsetting(ByVal sBreedtes As String)
        Column_Widths = sBreedtes
        Dim Col_Widths() As String = Column_Widths.Split(";")
        Dim ColLength As Integer = 0
        For indx As Integer = 0 To UBound(Col_Widths)
            ColLength += CType(Col_Widths(indx), Integer)
        Next
        MyBase.DropDownWidth = ColLength
    End Sub
    Public Sub Load_Data(ByVal dt As DataTable, ByVal Displaymember As String, ByVal Valuemember As String)
        If Not (dt Is Nothing) Then
            Data_Table = dt
            MyBase.DataSource = dt
            MyBase.ValueMember = Valuemember
            MyBase.DisplayMember = Displaymember
        End If
    End Sub
#End Region


#Region "Overrides"
    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)

        Dim myBrush As Brush = Nothing
        Dim LightColor As Color = Color.Azure
        Dim DarkColor As Color = Color.PowderBlue

        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality
        Select Case CInt((e.State And DrawItemState.Selected))
            Case DrawItemState.Selected
                myBrush = New SolidBrush(ForeColor)
                Render_Selection(e.Graphics, e.Bounds, 2.0!, True)
            Case Else
                myBrush = New SolidBrush(ForeColor)
                Render_Selection(e.Graphics, e.Bounds, 2.0!, False)
        End Select

        Dim str As String = ""
        Dim row As DataRow = Data_Table.Rows(e.Index)
        Dim newpos As Integer = e.Bounds.X
        Dim endpos As Integer = e.Bounds.X
        Dim Col_Widths() As String = Column_Widths.Split(";")

        For indx As Integer = 0 To UBound(Col_Widths)
            Dim ColLength As Integer = CType(Col_Widths(indx), Integer)
            endpos += ColLength
            Dim Charaant As Integer = CInt(Math.Round(CDbl(ColLength) / 6.2))
            Dim rawitem As String = row.Item(indx).ToString()
            If ColLength <> 0 Then
                If Charaant > rawitem.Length Then
                    str = rawitem
                Else
                    str = rawitem.Substring(0, Charaant)
                End If
                Dim r As RectangleF = New RectangleF(newpos + 2, e.Bounds.Y, endpos - 1, e.Bounds.Height)
                e.Graphics.DrawString(str, e.Font, myBrush, r)
                If indx <= UBound(Col_Widths) Then
                    e.Graphics.DrawLine(New Pen(Color.DimGray), endpos, e.Bounds.Y, endpos, Me.ItemHeight * Me.MaxDropDownItems)
                End If
            End If
            newpos = endpos
        Next
        If Not (myBrush Is Nothing) Then
            myBrush.Dispose()
        End If

    End Sub

    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        RaiseEvent On_Leaving(Me, EventArgs.Empty)
        If Not MyBase.Text = "" Then
            If MyBase.FindStringExact(MyBase.Text) = -1 Then
                Not_inList = True
                RaiseEvent On_Not_In_List(Me, EventArgs.Empty)
                RaiseEvent Not_inListChanged()
            Else
                Not_inList = False
                RaiseEvent On_Not_In_List(Me, EventArgs.Empty)
                RaiseEvent Not_inListChanged()
            End If
        End If
        MyBase.OnLeave(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)

        Dim foundIndex As Integer, textlngth As Integer
        If _DoNotReact = False Then
            If Me.AccessibilityObject.Value Is Nothing Then
                textlngth = 0
                Exit Sub
            Else
                textlngth = Me.AccessibilityObject.Value.Length
            End If
            If textlngth = 0 Then
                MyBase.OnTextChanged(e)
                _DoNotReact = False
                _Textchanged = False
                Exit Sub
            End If

            If textlngth <> 0 Then
                _DoNotReact = True
                foundIndex = FindString(Me.AccessibilityObject.Value)
                If foundIndex > -1 Then
                    Me.SelectedIndex = foundIndex
                    Me.Select(textlngth, Me.Text.Length - textlngth)
                    _Textchanged = True
                Else
                    _Textchanged = False
                End If
                _DoNotReact = False
            End If
            MyBase.OnTextChanged(e)
        End If
        _DoNotReact = False


    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Back, Keys.Enter, Keys.Delete
                _DoNotReact = True
            Case Keys.Down
                Me.DroppedDown = True
                Invalidate()
        End Select
        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
        If Not (MyBase.SelectedIndex = -1) Then

            Dim row As DataRow = Data_Table.Rows(MyBase.SelectedIndex)
            Try
                MyBase.SelectedValue = row.Item(MyBase.ValueMember)
            Catch ex As Exception

            End Try

            Dim i As Integer = 0
            For Each dc As DataColumn In Data_Table.Columns
                If i = 0 Then
                    ReDim Column_Values(i)
                    If Not (IsDBNull(row.Item(dc.ColumnName))) Then
                        Column_Values(i) = row.Item(dc.ColumnName).ToString
                    Else
                        Column_Values(i) = String.Empty
                    End If
                Else
                    ReDim Preserve Column_Values(i)
                    If Not (IsDBNull(row.Item(dc.ColumnName))) Then
                        Column_Values(i) = row.Item(dc.ColumnName).ToString
                    Else
                        Column_Values(i) = String.Empty
                    End If
                End If
                i += 1
            Next
            RaiseEvent On_Index_Changed(Me, EventArgs.Empty)
        End If
        MyBase.OnSelectedIndexChanged(e)
    End Sub

#End Region

End Class
