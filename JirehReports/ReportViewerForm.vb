Imports Microsoft.Reporting.WinForms
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class ReportViewerForm
    Inherits ReportViewer

    Public Sub AbrirRelatorioForm(ByVal DataSetOuLista As Object, ByVal Report As IReports)
        Try

            ''list of controls to add
            'Dim lista As New List(Of ToolStripDefinition)

            ''check box control
            'Dim cb As New CheckBox() With {.Text = "Expand All"}
            'lista.Add(New ToolStripDefinition() With { _
            '     .ToolStripControl = cb, _
            '     .Position = ToolStripPosition.After, _
            '     .ReportViewerToolStripControlName = Common.SeperatorAfterLastPage, _
            '     .ToolStripControlName = "checkBoxExpandAll" _
            '})

            ''button
            'Dim btn As New Button() With {.Text = "Fechar"}
            'lista.Add(New ToolStripDefinition() With { _
            '     .ToolStripControl = btn, _
            '     .Position = ToolStripPosition.After, _
            '     .ReportViewerToolStripControlName = Common.DocMap, _
            '     .ToolStripControlName = "btnFechar" _
            '})

            'Dim novo As New ReportViewerForm(lista)
            'AddHandler btn.Click, AddressOf novo.OnClickClose

            Dim Dados As New ReportDataSource(Report.NameTable, DataSetOuLista)
            MyBase.ProcessingMode = ProcessingMode.Local
            MyBase.LocalReport.ReportEmbeddedResource = Report.NameEmblasededReport
            MyBase.LocalReport.ReportPath = Report.NameLocalReport
            'F.rpVisual.LocalReport.ReportPath = "D:\Projetos Desenvolvimento 2015\Jireh Projetos\JirehReports\ComprovantePagamento.rdlc"
            MyBase.LocalReport.DataSources.Clear()
            MyBase.LocalReport.Refresh()
            MyBase.LocalReport.DataSources.Add(Dados)
            MyBase.LocalReport.Refresh()

            'Return novo
        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "Metodos sobrepostos para ser visualizado fora da DLL"

    Public Shadows Sub RefreshReport()
        MyBase.RefreshReport()
    End Sub

    Public Shadows Property ShowBackButton() As Boolean
        Get
            Return False
            'Return MyBase.ShowBackButton
        End Get
        Set(value As Boolean)
            MyBase.ShowBackButton = value
        End Set
    End Property

    Public Shadows Property ShowFindControls As Boolean
        Get
            Return False
            'Return MyBase.ShowFindControls
        End Get
        Set(value As Boolean)
            MyBase.ShowFindControls = value
        End Set
    End Property

    Protected Overrides Sub OnControlAdded(e As System.Windows.Forms.ControlEventArgs)
        'Me.SetToolStripItems(e.Control)
        MyBase.OnControlAdded(e)
    End Sub

#End Region

#Region "Configurar Toolbar Exports"

    Public Sub SetVisibleExportPDF()
        Try
            For Each et As RenderingExtension In MyBase.LocalReport.ListRenderingExtensions
                If et.Name <> "PDF" Then
                    ReflectivelySetVisibilityFalse(et)
                End If
            Next
            MyBase.SetDisplayMode(DisplayMode.PrintLayout)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ReflectivelySetVisibilityFalse(ByVal extension As RenderingExtension)
        Dim info As FieldInfo = extension.GetType().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
        If Not info Is Nothing Then
            info.SetValue(extension, False)
        End If
    End Sub

#End Region

    'Private Sub SetToolStripItems(c As Control)
    '    If ToolStripList Is Nothing OrElse ToolStripList.Count = 0 Then
    '        Exit Sub
    '    End If

    '    If TypeOf c Is ToolStrip Then
    '        Dim tsic As ToolStripItemCollection = DirectCast(c, ToolStrip).Items

    '        Dim index As Integer = 0
    '        For Each tsd As ToolStripDefinition In ToolStripList
    '            index = tsic.IndexOfKey(tsd.ReportViewerToolStripControlName) + (If(tsd.Position = ToolStripPosition.Before, -1, 1))
    '            If index < 0 Then
    '                Continue For
    '            End If

    '            If TypeOf tsd.ToolStripControl Is Control Then
    '                tsic.Insert(index, New ToolStripControlHost(DirectCast(tsd.ToolStripControl, Control)))
    '            Else
    '                tsic.Insert(index, TryCast(tsd.ToolStripControl, ToolStripItem))
    '            End If

    '            tsic(index).Name = tsd.ToolStripControlName
    '        Next
    '        Return
    '    End If
    '    For i As Integer = 0 To c.Controls.Count - 1
    '        SetToolStripItems(c.Controls(i))
    '    Next
    'End Sub

    '    Public Class ToolStripDefinition
    '        Public Property ToolStripControl() As Component
    '        Public Property ToolStripControlName() As String
    '        Public Property Position() As ToolStripPosition
    '        Public Property ReportViewerToolStripControlName() As String
    '    End Class

    '    Public NotInheritable Class Common
    '        Private Sub New()
    '        End Sub
    '#Region "ToolStrip Items"
    '        Public Shared ReadOnly DocMap As String = "docMap"
    '        Public Shared ReadOnly ShowParams As String = "showParams"
    '        Public Shared ReadOnly SeperatorAfterShowParams As String = "toolStripSeparator1"
    '        Public Shared ReadOnly FirstPage As String = "firstPage"
    '        Public Shared ReadOnly PreviousPage As String = "previousPage"
    '        Public Shared ReadOnly CurrentPage As String = "currentPage"
    '        Public Shared ReadOnly LabelOf As String = "labelOf"
    '        Public Shared ReadOnly TotalPages As String = "totalPages"
    '        Public Shared ReadOnly NextPage As String = "nextPage"
    '        Public Shared ReadOnly LastPage As String = "lastPage"
    '        Public Shared ReadOnly SeperatorAfterLastPage As String = "toolStripSeparator2"
    '        Public Shared ReadOnly Back As String = "back"
    '        Public Shared ReadOnly [Stop] As String = "stop"
    '        Public Shared ReadOnly Refresh As String = "refresh"
    '        Public Shared ReadOnly SeperatorAfterRefresh As String = "toolStripSeparator3"
    '        Public Shared ReadOnly Print As String = "print"
    '        Public Shared ReadOnly PrintPreview As String = "printPreview"
    '        Public Shared ReadOnly PageSetup As String = "pageSetup"
    '        Public Shared ReadOnly Export As String = "export"
    '        Public Shared ReadOnly SeparatorAfterExport As String = "separator4"
    '        Public Shared ReadOnly Zoom As String = "zoom"
    '        Public Shared ReadOnly TextToFind As String = "textToFind"
    '        Public Shared ReadOnly Find As String = "find"
    '        Public Shared ReadOnly SeperatorAfterFind As String = "toolStripSeparator4"
    '        Public Shared ReadOnly FindNext As String = "findNext"
    '#End Region

    '    End Class

    '    Public Enum ToolStripPosition
    '        Before
    '        After
    '    End Enum

    '    Protected Sub OnClickClose(ByVal sender As Object, ByVal e As EventArgs)
    '        RaiseEvent CloseReport(sender, e)
    '    End Sub

    '    Public Event CloseReport(ByVal sender As Object, ByVal e As EventArgs)

End Class
