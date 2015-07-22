Imports JirehReports
Imports System.Reflection

Public Class Relatorio

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shared Sub Visualizar(ByVal Report As JirehReports.IReports, ByVal Lista As Object)
        Try
            Dim F As New Relatorio
            F.rpVisual.AbrirRelatorioForm(Lista, Report)
            FormOpenMDI(F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Relatorio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FormCloseMDI(Me)
    End Sub

    Private Sub Relatorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.rpVisual.RefreshReport()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub rpVisual_Load(sender As Object, e As EventArgs) Handles rpVisual.Load
        Try
            rpVisual.SetVisibleExportPDF()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    ''Private Sub AddButtonFechar(ByRef Controle As Control)
    '    Try
    ''Dim x As Control = Controle.Controls.Find("toolStrip1", True)(0)

    ''If x IsNot Nothing Then

    ''    Dim btn As New Button
    ''    btn.Text = "Fechar"
    ''    btn.Name = "btnFechar"
    ''    AddHandler btn.Click, AddressOf btn_click
    ''    x.Controls.Add(btn)

    ''End If
    '        If Controle.Equals(GetType(ToolStrip)) Then

    'Dim lista As ToolStripItemCollection = DirectCast(Controle, ToolStrip).Items
    'Dim btn As New Button
    '            btn.Text = "Fechar"
    '            btn.Name = "btnFechar"
    '            AddHandler btn.Click, AddressOf btn_click
    '            lista.Add(New ToolStripControlHost(btn))

    '        ElseIf Controle.Controls.Count > 0 Then
    '            For Each i As Control In Controle.Controls
    '                AddButtonFechar(i)
    '            Next
    '        End If
    ''For Each c As Control In Controle.Controls

    ''    If c.ToString = "Microsoft.Reporting.WebForms.ToolbarControl" Then

    ''        For Each i As Control In c.Controls

    ''            If i.ToString = "Microsoft.Reporting.WebForms.PageNavigationGroup" Then

    ''                Dim btn As New Button
    ''                btn.Text = "Fechar"
    ''                btn.Name = "btnFechar"
    ''                AddHandler btn.Click, AddressOf btn_click
    ''                i.Controls.Add(btn)
    ''            End If

    ''        Next

    ''    ElseIf c.Controls.Count > 0 Then
    ''        AddButtonFechar(c)
    ''    End If

    ''Next
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub

End Class

'private void AddPrintBtn()
'    {           
'        foreach (Control c in rv.Controls)
'        {
'            foreach (Control c1 in c.Controls)
'            {
'                foreach (Control c2 in c1.Controls)
'                {
'                    foreach (Control c3 in c2.Controls)
'                    {
'                        if (c3.ToString() == "Microsoft.Reporting.WebForms.ToolbarControl")
'                        {
'                            foreach (Control c4 in c3.Controls)
'                            {
'                                if (c4.ToString() == "Microsoft.Reporting.WebForms.PageNavigationGroup")
'                                {
'                                    var btn = new Button();
'                                    btn.Text = "Criteria";
'                                    btn.ID = "btnFlip";
'                                    btn.OnClientClick = "$('#pnl').toggle();";
'                                    c4.Controls.Add(btn);
'                                    return;
'                                }
'                            }
'                        }
'                    }
'                }
'            }
'        }
'    }

'Imports System.Reflection
'Imports Microsoft.Reporting.WinForms
'Imports Microsoft.SqlServer.ReportingServices2005.Execution

'Public Class ServerReportDecorator
'    Private serverReport As LocalReport
'    Public Sub New(ByRef reportViewer As ReportViewer)
'        Me.serverReport = reportViewer.LocalReport
'    End Sub
'    Public Sub DisableUnwantedExportFormats(ByVal displayXmlFormat As Boolean)
'        For Each extension As RenderingExtension In serverReport.ListRenderingExtensions()
'            If extension.Name = "IMAGE" Or extension.Name = "MHTML" Then
'                ReflectivelySetVisibilityFalse(extension)
'            ElseIf extension.Name = "XML" AndAlso displayXmlFormat Then
'                ReflectivelySetLocalizedName(extension, "MS Word")
'            ElseIf extension.Name = "XML" Then
'                ReflectivelySetVisibilityFalse(extension)
'            End If
'        Next
'    End Sub
'    Private Sub ReflectivelySetVisibilityFalse(ByVal extension As RenderingExtension)
'        Dim info As FieldInfo = extension.GetType().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
'        If Not info Is Nothing Then
'            info.SetValue(extension, False)
'        End If
'    End Sub
'    Private Sub ReflectivelySetLocalizedName(ByVal extension As RenderingExtension, ByVal newName As String)
'        Dim info As FieldInfo = extension.GetType().GetField("m_localizedName", BindingFlags.NonPublic Or BindingFlags.Instance)
'        If Not info Is Nothing Then
'            info.SetValue(extension, newName)
'        End If
'    End Sub
'End Class