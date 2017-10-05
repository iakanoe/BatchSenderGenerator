Public Class form
    Sub selectfile()
        MsgBox("Debe seleccionar un archivo de texto ("".txt"")  el cual contenga por cada línea con formato ""[IP DESTINO]:[PUERTO DESTINO] [MENSAJE HEXADECIMAL]"".", vbInformation)
        Dim fd As New Windows.Forms.OpenFileDialog
        fd.CheckFileExists = True
        fd.CheckPathExists = True
        fd.Filter = "Archivos de texto (*.txt)|*.txt"
        fd.Multiselect = False
        fd.Title = "Seleccionar archivo..."
        fd.ShowDialog()
        entrada = fd.FileName
        Close()
    End Sub
    Sub select2file()
        MsgBox("Debe seleccionar donde guardar el archivo de comandos ("".bat"") de salida.", vbInformation)
        Dim sfd As New Windows.Forms.SaveFileDialog
        sfd.AddExtension = True
        sfd.CheckPathExists = True
        sfd.Filter = "Archivo de comandos (*.bat)|*.bat"
        sfd.OverwritePrompt = True
        sfd.Title = "Guardar archivo..."
        sfd.ShowDialog()
        salida = sfd.FileName
        Close()
    End Sub
End Class