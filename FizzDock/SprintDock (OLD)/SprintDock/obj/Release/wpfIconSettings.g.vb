﻿#ExternalChecksum("..\..\wpfIconSettings.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","C90FEB61D9F484EC4C66CE4DE25E2269")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3053
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Forms.Integration
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes


'''<summary>
'''wpfIconSettings
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class wpfIconSettings
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",4)
    Friend WithEvents Window1 As wpfIconSettings
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",86)
    Friend WithEvents grdMain As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",87)
    Friend WithEvents lstName As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",90)
    Friend WithEvents lstIcon As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",91)
    Friend WithEvents lstPath As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",92)
    Friend WithEvents img As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",93)
    Friend WithEvents img2 As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",94)
    Friend WithEvents TabControl1 As System.Windows.Controls.TabControl
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",95)
    Friend WithEvents TabItem1 As System.Windows.Controls.TabItem
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",96)
    Friend WithEvents grdIcons As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",97)
    Friend WithEvents lstIcons As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",104)
    Friend WithEvents cmdAdd As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",105)
    Friend WithEvents cmdRemove As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",108)
    Friend WithEvents TabItem2 As System.Windows.Controls.TabItem
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",112)
    Friend WithEvents txtName As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",113)
    Friend WithEvents txtTarget As System.Windows.Controls.ComboBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",118)
    Friend WithEvents Label1 As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",119)
    Friend WithEvents Label2 As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",122)
    Friend WithEvents imgPreview As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",125)
    Friend WithEvents cmdAddIcon As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",126)
    Friend WithEvents cmdBrowse As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\wpfIconSettings.xaml",132)
    Friend WithEvents cmdSave As System.Windows.Controls.Button
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/SprintDock;component/wpficonsettings.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\wpfIconSettings.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.Window1 = CType(target,wpfIconSettings)
            Return
        End If
        If (connectionId = 4) Then
            Me.grdMain = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 5) Then
            Me.lstName = CType(target,System.Windows.Controls.ListBox)
            Return
        End If
        If (connectionId = 6) Then
            Me.lstIcon = CType(target,System.Windows.Controls.ListBox)
            Return
        End If
        If (connectionId = 7) Then
            Me.lstPath = CType(target,System.Windows.Controls.ListBox)
            Return
        End If
        If (connectionId = 8) Then
            Me.img = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 9) Then
            Me.img2 = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 10) Then
            Me.TabControl1 = CType(target,System.Windows.Controls.TabControl)
            Return
        End If
        If (connectionId = 11) Then
            Me.TabItem1 = CType(target,System.Windows.Controls.TabItem)
            Return
        End If
        If (connectionId = 12) Then
            Me.grdIcons = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 13) Then
            Me.lstIcons = CType(target,System.Windows.Controls.ListBox)
            Return
        End If
        If (connectionId = 14) Then
            Me.cmdAdd = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 15) Then
            Me.cmdRemove = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 16) Then
            Me.TabItem2 = CType(target,System.Windows.Controls.TabItem)
            Return
        End If
        If (connectionId = 17) Then
            Me.txtName = CType(target,System.Windows.Controls.TextBox)
            Return
        End If
        If (connectionId = 18) Then
            Me.txtTarget = CType(target,System.Windows.Controls.ComboBox)
            Return
        End If
        If (connectionId = 19) Then
            Me.Label1 = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 20) Then
            Me.Label2 = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 21) Then
            Me.imgPreview = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 22) Then
            Me.cmdAddIcon = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 23) Then
            Me.cmdBrowse = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 24) Then
            Me.cmdSave = CType(target,System.Windows.Controls.Button)
            Return
        End If
        Me._contentLoaded = true
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")>  _
    Sub System_Windows_Markup_IStyleConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IStyleConnector.Connect
        If (connectionId = 2) Then
            
            #ExternalSource("..\..\wpfIconSettings.xaml",18)
            AddHandler CType(target,System.Windows.Controls.Button).Click, New System.Windows.RoutedEventHandler(AddressOf Me.Del)
            
            #End ExternalSource
        End If
        If (connectionId = 3) Then
            
            #ExternalSource("..\..\wpfIconSettings.xaml",22)
            AddHandler CType(target,System.Windows.Controls.Button).Click, New System.Windows.RoutedEventHandler(AddressOf Me.Input)
            
            #End ExternalSource
        End If
    End Sub
End Class