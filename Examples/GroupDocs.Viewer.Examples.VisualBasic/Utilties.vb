﻿
Imports GroupDocs.Viewer.Config
Imports GroupDocs.Viewer.Converter.Options
Imports GroupDocs.Viewer.Domain
Imports GroupDocs.Viewer.Domain.Options
Imports GroupDocs.Viewer.Handler
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Text
Imports GroupDocs.Viewer.Domain.Containers
Imports GroupDocs.Viewer.Domain.Html
Imports GroupDocs.Viewer.Domain.Image

Namespace GroupDocs.Viewer.Examples
    Public NotInheritable Class Utilities
        Private Sub New()
        End Sub
        Public Const StoragePath As String = "../../../Data/Storage/"
        Public Const OutputHtmlPath As String = "../../../Data/Output/html/"
        Public Const OutputImagePath As String = "../../../Data/Output/images/"
        Public Const OutputPath As String = "../../../Data/Output/"
        Public Const licensePath As String = "../../../Data/Storage/GroupDocs.Total.lic"

#Region "Configurations"


        ''' <summary>
        ''' Initialize, populate and return the ViewerConfig object
        ''' </summary>
        ''' <returns>Populated ViewerConfig Object</returns>
        Public Shared Function GetConfigurations() As ViewerConfig
            'ExStart:Configurations
            Dim config As New ViewerConfig()
            'set the storage path
            config.StoragePath = StoragePath
            'Uncomment the below line for cache purpose
            'config.UseCache = true;
            Return config
            'ExEnd:Configurations

        End Function

        ''' <summary>
        ''' Initialize, populate and return the ViewerConfig object
        ''' </summary>
        ''' <param name="DefaultFontName">Font Name</param>
        ''' <returns>Populated ViewerConfig Object</returns>
        Public Shared Function GetConfigurations(DefaultFontName As String) As ViewerConfig
            'ExStart:ConfigurationsWithDefaultFontName
            Dim config As New ViewerConfig()
            'set the storage path
            config.StoragePath = StoragePath
            'Uncomment the below line for cache purpose
            'config.UseCache = true;
            'Set default font name
            config.DefaultFontName = DefaultFontName
            Return config
            'ExEnd:ConfigurationsWithDefaultFontName

        End Function



#End Region

#Region "Transformations"

        Public NotInheritable Class PageTransformations
            Private Sub New()
            End Sub
            ''' <summary>
            '''  Rotate a Page before rendering html
            ''' </summary>
            ''' <param name="handler"></param>
            ''' <param name="guid"></param>
            ''' <param name="PageNumber"></param>
            ''' <param name="angle"></param>
            ''' <remarks></remarks>
            Public Shared Sub RotatePages(ByRef handler As ViewerHandler(Of PageHtml), guid As [String], PageNumber As Integer, angle As Integer)
                'ExStart:rotationAngle
                ' Set the property of handler's rotate Page
                handler.RotatePage(New RotatePageOptions(guid, PageNumber, angle))
                'ExEnd:rotationAngle
            End Sub
            ''' <summary>
            '''  Rotate a Page before rendering image
            ''' </summary>
            ''' <param name="handler"></param>
            ''' <param name="guid"></param>
            ''' <param name="PageNumber"></param>
            ''' <param name="angle"></param>
            ''' <remarks></remarks>
            Public Shared Sub RotatePages(ByRef handler As ViewerHandler(Of PageImage), guid As [String], PageNumber As Integer, angle As Integer)
                'ExStart:rotationAngle
                ' Set the property of handler's rotate Page
                handler.RotatePage(New RotatePageOptions(guid, PageNumber, angle))
                'ExEnd:rotationAngle
            End Sub
            ''' <summary>
            ''' Reorder a page before rendering
            ''' </summary>
            ''' <param name="Handler">Base class of handlers</param>
            ''' <param name="guid">File name</param>
            ''' <param name="currentPageNumber">Existing number of page</param>
            ''' <param name="newPageNumber">New number of page</param>
            Public Shared Sub ReorderPage(ByRef Handler As ViewerHandler(Of PageHtml), guid As [String], currentPageNumber As Integer, newPageNumber As Integer)
                'ExStart:reorderPage
                'Initialize the ReorderPageOptions object by passing guid as document name, current Page Number, new page number
                Dim options As New ReorderPageOptions(guid, currentPageNumber, newPageNumber)
                ' call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions object.
                Handler.ReorderPage(options)
                'ExEnd:reorderPage
            End Sub
            ''' <summary>
            ''' Reorder a page before rendering
            ''' </summary>
            ''' <param name="Handler">Base class of handlers</param>
            ''' <param name="guid">File name</param>
            ''' <param name="currentPageNumber">Existing number of page</param>
            ''' <param name="newPageNumber">New number of page</param>
            Public Shared Sub ReorderPage(ByRef Handler As ViewerHandler(Of PageImage), guid As [String], currentPageNumber As Integer, newPageNumber As Integer)
                'ExStart:reorderPage
                'Initialize the ReorderPageOptions object by passing guid as document name, current Page Number, new page number
                Dim options As New ReorderPageOptions(guid, currentPageNumber, newPageNumber)
                ' call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions object.
                Handler.ReorderPage(options)
                'ExEnd:reorderPage
            End Sub
            ''' <summary>
            ''' add a watermark text to all rendered images.
            ''' </summary>
            ''' <param name="options">HtmlOptions by reference</param>
            ''' <param name="text">Watermark text</param>
            ''' <param name="color">System.Drawing.Color</param>
            ''' <param name="position"></param>
            ''' <param name="width"></param>
            Public Shared Sub AddWatermark(ByRef options As ImageOptions, text As [String], color As Color, position As WatermarkPosition, width As Integer)
                'ExStart:AddWatermark
                'Initialize watermark object by passing the text to display.
                Dim watermark As New Watermark(text)
                'Apply the watermark color by assigning System.Drawing.Color.
                watermark.Color = color
                'Set the watermark's position by assigning an enum WatermarkPosition's value.
                watermark.Position = position
                'set an integer value as watermark width 
                watermark.Width = width
                ' Set font name
                watermark.FontName = "MS Gothic"
                'Assign intialized and populated watermark object to ImageOptions or HtmlOptions objects
                options.Watermark = watermark
                'ExEnd:AddWatermark
            End Sub
            ''' <summary>
            ''' add a watermark text to all rendered Html pages.
            ''' </summary>
            ''' <param name="options">HtmlOptions by reference</param>
            ''' <param name="text">Watermark text</param>
            ''' <param name="color">System.Drawing.Color</param>
            ''' <param name="position"></param>
            ''' <param name="width"></param>
            Public Shared Sub AddWatermark(ByRef options As HtmlOptions, text As [String], color As Color, position As WatermarkPosition, width As Integer)

                Dim watermark As New Watermark(text)
                watermark.Color = color
                watermark.Position = position
                watermark.Width = width
                watermark.FontName = """Comic Sans MS"", cursive, sans-serif"
                options.Watermark = watermark
            End Sub

        End Class

#End Region

#Region "ProductLicense"

        ''' <summary>
        ''' Set product's license for HTML Handler
        ''' </summary>
        Public Shared Sub ApplyLicense()
            Dim lic As New License()
            lic.SetLicense(licensePath)
        End Sub
        

#End Region

#Region "OutputHandling"
        ''' <summary>
        ''' Save file in html form
        ''' </summary>
        ''' <param name="filename">Save as provided string</param>
        ''' <param name="content">Html contents in String form</param>
        Public Shared Sub SaveAsHtml(filename As [String], content As [String])
            Try
                'ExStart:SaveAsHTML
                ' set an html file name with absolute path
                Dim fname As [String] = Path.Combine(Path.GetFullPath(OutputHtmlPath), Path.GetFileNameWithoutExtension(filename) + ".html")

                ' create a file at the disk
                'ExEnd:SaveAsHTML
                System.IO.File.WriteAllText(fname, content)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            End Try

        End Sub
        ''' <summary>
        ''' Save the rendered images at disk
        ''' </summary>
        ''' <param name="imageName">Save as provided string</param>
        ''' <param name="imageContent">stream of image contents</param>
        Public Shared Sub SaveAsImage(imageName As [String], imageContent As Stream)
            Try
                'ExStart:SaveAsImage
                ' extract the image from stream
                Dim img As Image = Image.FromStream(imageContent)

                'save the image in the form of jpeg
                'ExEnd:SaveAsImage
                img.Save(Path.Combine(Path.GetFullPath(OutputImagePath), Path.GetFileNameWithoutExtension(imageName)) + ".Jpeg", ImageFormat.Jpeg)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Save file in any format
        ''' </summary>
        ''' <param name="filename">Save as provided string</param>
        ''' <param name="content">Stream as content of a file</param>
        Public Shared Sub SaveFile(filename As [String], content As Stream)
            Try
                'ExStart:SaveAnyFile
                'Create file stream
                Dim fileStream As FileStream = File.Create(Path.Combine(Path.GetFullPath(OutputPath), filename), CInt(content.Length))

                ' Initialize the bytes array with the stream length and then fill it with data
                Dim bytesInStream As Byte() = New Byte(content.Length - 1) {}
                content.Read(bytesInStream, 0, bytesInStream.Length)

                ' Use write method to write to the file specified above
                'ExEnd:SaveAnyFile
                fileStream.Write(bytesInStream, 0, bytesInStream.Length)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Load directory structure as file tree
        ''' </summary>
        ''' <param name="Path"></param>
        Public Shared Sub LoadFileTree(Path As [String])
            'ExStart:LoadFileTree
            ' Create/initialize image handler 
            Dim imageHandler As New ViewerImageHandler(Utilities.GetConfigurations())

            ' Load file tree list for custom path 
            Dim options = New FileTreeOptions(Path)

            ' Load file tree list for ViewerConfig.StoragePath
            Dim container As FileTreeContainer = imageHandler.LoadFileTree(options)

            For Each node In container.FileTree
                If node.IsDirectory Then
                    Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}", node.Guid, node.Name, node.LastModificationDate)
                Else
                    Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}", node.Guid, node.Name, node.DocumentType, node.FileType, node.Extension, _
                        node.Size, node.LastModificationDate)
                End If
            Next

            'ExEnd:LoadFioleTree

        End Sub
        ''' <summary>
        ''' Get document stream
        ''' </summary>
        ''' <param name="DocumentName">Input document name</param> 
        Public Shared Function GetDocumentStream(DocumentName As String) As Stream
            Try
                'ExStart:GetDocumentStream
                Dim fsSource As New FileStream(StoragePath & DocumentName, FileMode.Open, FileAccess.Read)

                ' Read the source file into a byte array.
                Dim bytes As Byte() = New Byte(fsSource.Length - 1) {}
                Dim numBytesToRead As Integer = CInt(fsSource.Length)
                Dim numBytesRead As Integer = 0
                While numBytesToRead > 0
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, numBytesToRead)

                    ' Break when the end of the file is reached.
                    If n = 0 Then
                        Exit While
                    End If

                    numBytesRead += n
                    numBytesToRead -= n
                End While
                numBytesToRead = bytes.Length



                'ExEnd:GetDocumentStream
                Return fsSource
            Catch ioEx As FileNotFoundException
                Console.WriteLine(ioEx.Message)
                Return Nothing
            End Try
        End Function
#End Region
    End Class

End Namespace

