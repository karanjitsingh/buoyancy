﻿#ExternalChecksum("..\..\App.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","01B8ACDF5198A4E13D55E8D0B3A07D99")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3615
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
'''App
'''</summary>
Partial Public Class App
    Inherits System.Windows.Application
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub InitializeComponent()
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        
        #ExternalSource("..\..\App.xaml",5)
        Me.StartupUri = New System.Uri("wpfMain.xaml", System.UriKind.Relative)
        
        #End ExternalSource
        Dim resourceLocater As System.Uri = New System.Uri("/Sudoku_Solver;component/app.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\App.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    '''<summary>
    '''Application Entry Point.
    '''</summary>
    <System.STAThreadAttribute(),  _
     System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Shared Sub Main()
        Dim app As App = New App
        app.InitializeComponent
        app.Run
    End Sub
End Class
