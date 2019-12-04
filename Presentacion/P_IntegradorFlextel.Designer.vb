<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class P_IntegradorFlextel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gpBase = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbRutaSalida = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btCambiar = New DevComponents.DotNetBar.ButtonX()
        Me.dtiFachisFechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.dtiFachisFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btFachis = New DevComponents.DotNetBar.ButtonX()
        Me.btStomov = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.dtiStomovFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dtiStomovFechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.gpBase.SuspendLayout()
        CType(Me.dtiFachisFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiFachisFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiStomovFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiStomovFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpBase
        '
        Me.gpBase.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpBase.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpBase.Controls.Add(Me.btStomov)
        Me.gpBase.Controls.Add(Me.LabelX4)
        Me.gpBase.Controls.Add(Me.dtiStomovFechaFin)
        Me.gpBase.Controls.Add(Me.LabelX5)
        Me.gpBase.Controls.Add(Me.dtiStomovFechaIni)
        Me.gpBase.Controls.Add(Me.btFachis)
        Me.gpBase.Controls.Add(Me.LabelX3)
        Me.gpBase.Controls.Add(Me.dtiFachisFechaFin)
        Me.gpBase.Controls.Add(Me.LabelX2)
        Me.gpBase.Controls.Add(Me.dtiFachisFechaIni)
        Me.gpBase.Controls.Add(Me.btCambiar)
        Me.gpBase.Controls.Add(Me.tbRutaSalida)
        Me.gpBase.Controls.Add(Me.LabelX1)
        Me.gpBase.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpBase.Location = New System.Drawing.Point(0, 0)
        Me.gpBase.Name = "gpBase"
        Me.gpBase.Size = New System.Drawing.Size(800, 450)
        '
        '
        '
        Me.gpBase.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.gpBase.Style.BackColorGradientAngle = 90
        Me.gpBase.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.gpBase.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBase.Style.BorderBottomWidth = 1
        Me.gpBase.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpBase.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBase.Style.BorderLeftWidth = 1
        Me.gpBase.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBase.Style.BorderRightWidth = 1
        Me.gpBase.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBase.Style.BorderTopWidth = 1
        Me.gpBase.Style.CornerDiameter = 4
        Me.gpBase.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpBase.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpBase.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpBase.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpBase.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpBase.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpBase.TabIndex = 0
        Me.gpBase.Text = "G E N E R A R   T X T "
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Ruta de Salida:"
        '
        'tbRutaSalida
        '
        '
        '
        '
        Me.tbRutaSalida.Border.Class = "TextBoxBorder"
        Me.tbRutaSalida.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbRutaSalida.Location = New System.Drawing.Point(109, 6)
        Me.tbRutaSalida.Name = "tbRutaSalida"
        Me.tbRutaSalida.PreventEnterBeep = True
        Me.tbRutaSalida.Size = New System.Drawing.Size(517, 23)
        Me.tbRutaSalida.TabIndex = 1
        '
        'btCambiar
        '
        Me.btCambiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCambiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btCambiar.Location = New System.Drawing.Point(632, 6)
        Me.btCambiar.Name = "btCambiar"
        Me.btCambiar.Size = New System.Drawing.Size(75, 23)
        Me.btCambiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCambiar.TabIndex = 2
        Me.btCambiar.Text = "Cambiar"
        Me.btCambiar.Visible = False
        '
        'dtiFachisFechaIni
        '
        '
        '
        '
        Me.dtiFachisFechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFachisFechaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFachisFechaIni.ButtonDropDown.Visible = True
        Me.dtiFachisFechaIni.IsPopupCalendarOpen = False
        Me.dtiFachisFechaIni.Location = New System.Drawing.Point(109, 61)
        '
        '
        '
        '
        '
        '
        Me.dtiFachisFechaIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaIni.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiFachisFechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFachisFechaIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaIni.MonthCalendar.DisplayMonth = New Date(2018, 5, 1, 0, 0, 0, 0)
        Me.dtiFachisFechaIni.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtiFachisFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFachisFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFachisFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFachisFechaIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaIni.MonthCalendar.TodayButtonVisible = True
        Me.dtiFachisFechaIni.Name = "dtiFachisFechaIni"
        Me.dtiFachisFechaIni.Size = New System.Drawing.Size(100, 23)
        Me.dtiFachisFechaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFachisFechaIni.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 61)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 23)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Fecha Inicial:"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(215, 61)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 23)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "Fecha Final:"
        '
        'dtiFachisFechaFin
        '
        '
        '
        '
        Me.dtiFachisFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFachisFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFachisFechaFin.ButtonDropDown.Visible = True
        Me.dtiFachisFechaFin.IsPopupCalendarOpen = False
        Me.dtiFachisFechaFin.Location = New System.Drawing.Point(321, 61)
        '
        '
        '
        '
        '
        '
        Me.dtiFachisFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiFachisFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFachisFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaFin.MonthCalendar.DisplayMonth = New Date(2018, 5, 1, 0, 0, 0, 0)
        Me.dtiFachisFechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtiFachisFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFachisFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFachisFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFachisFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFachisFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.dtiFachisFechaFin.Name = "dtiFachisFechaFin"
        Me.dtiFachisFechaFin.Size = New System.Drawing.Size(100, 23)
        Me.dtiFachisFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFachisFechaFin.TabIndex = 5
        '
        'btFachis
        '
        Me.btFachis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFachis.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFachis.Location = New System.Drawing.Point(436, 61)
        Me.btFachis.Name = "btFachis"
        Me.btFachis.Size = New System.Drawing.Size(75, 23)
        Me.btFachis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btFachis.TabIndex = 7
        Me.btFachis.Text = "Fachis"
        '
        'btStomov
        '
        Me.btStomov.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btStomov.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btStomov.Location = New System.Drawing.Point(436, 90)
        Me.btStomov.Name = "btStomov"
        Me.btStomov.Size = New System.Drawing.Size(75, 23)
        Me.btStomov.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btStomov.TabIndex = 13
        Me.btStomov.Text = "Stomov"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(215, 90)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 23)
        Me.LabelX4.TabIndex = 12
        Me.LabelX4.Text = "Fecha Final:"
        '
        'dtiStomovFechaFin
        '
        '
        '
        '
        Me.dtiStomovFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiStomovFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiStomovFechaFin.ButtonDropDown.Visible = True
        Me.dtiStomovFechaFin.IsPopupCalendarOpen = False
        Me.dtiStomovFechaFin.Location = New System.Drawing.Point(321, 90)
        '
        '
        '
        '
        '
        '
        Me.dtiStomovFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiStomovFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiStomovFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaFin.MonthCalendar.DisplayMonth = New Date(2018, 5, 1, 0, 0, 0, 0)
        Me.dtiStomovFechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtiStomovFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiStomovFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiStomovFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiStomovFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.dtiStomovFechaFin.Name = "dtiStomovFechaFin"
        Me.dtiStomovFechaFin.Size = New System.Drawing.Size(100, 23)
        Me.dtiStomovFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiStomovFechaFin.TabIndex = 11
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(3, 90)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 23)
        Me.LabelX5.TabIndex = 10
        Me.LabelX5.Text = "Fecha Inicial:"
        '
        'dtiStomovFechaIni
        '
        '
        '
        '
        Me.dtiStomovFechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiStomovFechaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiStomovFechaIni.ButtonDropDown.Visible = True
        Me.dtiStomovFechaIni.IsPopupCalendarOpen = False
        Me.dtiStomovFechaIni.Location = New System.Drawing.Point(109, 90)
        '
        '
        '
        '
        '
        '
        Me.dtiStomovFechaIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaIni.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiStomovFechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiStomovFechaIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaIni.MonthCalendar.DisplayMonth = New Date(2018, 5, 1, 0, 0, 0, 0)
        Me.dtiStomovFechaIni.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtiStomovFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiStomovFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiStomovFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiStomovFechaIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiStomovFechaIni.MonthCalendar.TodayButtonVisible = True
        Me.dtiStomovFechaIni.Name = "dtiStomovFechaIni"
        Me.dtiStomovFechaIni.Size = New System.Drawing.Size(100, 23)
        Me.dtiStomovFechaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiStomovFechaIni.TabIndex = 9
        '
        'P_IntegradorFlextel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gpBase)
        Me.Name = "P_IntegradorFlextel"
        Me.Text = "P_IntegradorFlextel"
        Me.gpBase.ResumeLayout(False)
        CType(Me.dtiFachisFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiFachisFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiStomovFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiStomovFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpBase As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtiFachisFechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents btCambiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbRutaSalida As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btStomov As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtiStomovFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtiStomovFechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents btFachis As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtiFachisFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
