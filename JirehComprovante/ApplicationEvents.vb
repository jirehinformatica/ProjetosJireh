﻿Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

#Region "Timer de controle geral"

        Private MostrarErroTimeSistema As Boolean
        Protected WithEvents TimeSistema As Timer

        Private Sub TimeSistema_Tick(sender As Object, e As EventArgs) Handles TimeSistema.Tick
            Try
                DataHoraServidor = DataHoraServidor.AddMinutes(1)
                FormularioMDI.SetDataHora(DataHoraServidor)
                DoEvents()
            Catch ex As Exception
                If MostrarErroTimeSistema Then
                    TratarErros(ex)
                End If
                MostrarErroTimeSistema = False
            End Try
        End Sub

#End Region

        Protected Overrides Function OnInitialize(commandLineArgs As ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            TimeSistema = New Timer
            'intervalo para 1 minuto
            TimeSistema.Interval = 60000
            MostrarErroTimeSistema = True
            Return MyBase.OnInitialize(commandLineArgs)
        End Function

        Protected Overrides Sub OnRun()
            SetMDI(Global.JirehComprovante.MdiComprovante)

            Dim F As New ssAbertura
            F.Show()
            DoEvents()

            F.AddPasso("Iniciando o sistema")
            F.AddPasso("Checando a versão do sistema")
            FormularioMDI.SetVersao()

            F.AddPasso("Iniciando prompt de mensagem")
            FormularioMDI.SetProgresso(0, , True)
            FormularioMDI.SetPrompt()

            F.AddPasso("Conectando ao banco de dados na internet")
            If Not JirehBDUtil.OpenConexaoMySQL() Then
                Alerta(JirehBDUtil.OpenConexaoMySQLMensagem)
                F.Close()
                F.Dispose()
                Exit Sub
            End If

            F.AddPasso("Verificando a chave de ativacao do sistema. Aguarde...")
            JirehBDUtil.InfoRegistro = New JirehBDUtil.ChaveExecucao

            F.AddPasso("Buscando a data e hora do servidor")
            Dim Buscar As New JirehBDUtil.Dal_Geral(JirehBDUtil.CnMySQL)
            DataHoraServidor = Buscar.GetDataHoraServidor

            F.AddPasso("Iniciando o timer do sistema")
            FormularioMDI.SetDataHora(DataHoraServidor)
            TimeSistema.Start()

            F.AddPasso("Verificando se o sistema está ativo")
            If Not JirehBDUtil.InfoRegistro.InformacoesUso.Ativo Then
                If JirehBDUtil.InfoRegistro.SerialHDLocal.Length = 0 Then
                    Alerta("Não é possível fazer a ativaçao do sistema sem a utilização de um disco local.")
                    Exit Sub
                End If
                JirehBDUtil.InfoRegistro.InformacoesUso.Serial = JirehBDUtil.InfoRegistro.SerialHDLocal(0)
                F.Hide()
                Dim Ativ As New AtivadorSistema
                Ativ.ShowDialog()
                Ativ.Dispose()
                If Not JirehBDUtil.InfoRegistro.InformacoesUso.Ativo Then
                    F.Dispose()
                    Exit Sub
                End If
                F.Show()
            End If

            F.AddPasso("Ativando o terminal")
            FormularioMDI.SetTerminal(JirehBDUtil.InfoRegistro.InformacoesUso.Estacao)

            F.AddPasso("Validando os convênios de uso do sistema")

            Threading.Thread.Sleep(500)

            F.Close()
            F.Dispose()
            If Not JirehBDUtil.InfoRegistro.InformacoesUso.Ativo Then
                Exit Sub
            End If
            MyBase.OnRun()
        End Sub

        Protected Overrides Sub OnShutdown()
            TimeSistema.Stop()
            TimeSistema.Dispose()
            MyBase.OnShutdown()
        End Sub
    End Class

End Namespace
